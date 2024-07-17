using Microsoft.EntityFrameworkCore;
using WebApplicationBase.Models.Entities;
using WebApplicationBase.ViewModels;

namespace WebApplicationBase.Services
{
    /// <summary> 主頁 Interface </summary>
    public interface IProductInfoService
    {
        /// <summary> 取得所有資料 </summary>
        /// <returns></returns>
         IQueryable<FvmProductInfo.VM_Data> GetSearchList();

        /// <summary> 取得單一資料 </summary>
        /// <param name="id">模型id</param>
        /// <returns></returns>
         Task<FvmProductInfo.VM_Data> GetAsync(int id);

        /// <summary> 新增、更新 </summary>
        /// <param name="model">新增、更新 模型</param>
        /// <returns></returns>
         Task UpdateAsync(FvmProductInfo.VM_Data model);

        /// <summary> 刪除 </summary>
        /// <param name="id">模型id<</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);
    }


    /// <summary> 主頁 Service </summary>
    public class ProductInfoService: IProductInfoService
    {
        private readonly WebApplicationBaseContext context;

        /// <summary> 建構子 </summary>
        /// <param name="context"></param>
        public ProductInfoService(WebApplicationBaseContext context)
        {
            this.context = context;
        }

        /// <summary> 取得所有資料 </summary>
        /// <returns></returns>
        public IQueryable<FvmProductInfo.VM_Data> GetSearchList()
        {
            var query = from productInfos in context.ProductInfos
                        select new FvmProductInfo.VM_Data
                        {
                            Id = productInfos.Id,                             
                            Name = productInfos.Name,                             
                            Price = productInfos.Price,
                        };
            return query;
        }

        /// <summary> 取得單一資料 </summary>
        /// <param name="id">模型id</param>
        /// <returns></returns>
        public async Task<FvmProductInfo.VM_Data> GetAsync(int id)
        {
            var model = await (from productInfos in context.ProductInfos                               
                               where productInfos.Id == id
                               select new FvmProductInfo.VM_Data
                               {
                                   Id = productInfos.Id,                                    
                                   Name = productInfos.Name,                                     
                                   Price = productInfos.Price,                           
                               }).FirstOrDefaultAsync();
            if (model == null)
            {
                throw new InvalidDataException("找不到該筆資料");
            }
            return model;
        }

        /// <summary> 更新 </summary>
        /// <param name="model">更新模型</param>
        /// <returns></returns>
        public async Task UpdateAsync(FvmProductInfo.VM_Data model)
        {
            //寫法1
            //資料異動如果出問題此SQL交易則取消(RollbackAsync)
            await using (var transaction = await context.Database.BeginTransactionAsync())
            {
                if (model.Id == 0)
                {
                    var productInfos = new ProductInfo()
                    {
                        Name = model.Name,
                        Price = model.Price,
                    };

                    await context.ProductInfos.AddAsync(productInfos);

                }
                else
                {
                    var entity = await context.ProductInfos.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
                    if (entity == null)
                    {
                        throw new InvalidDataException("找不到該筆資料");
                    }
                    //因Entity Framework Core會自動追蹤實體的變更，不用呼叫Update() ，呼叫 SaveChangesAsync()會自動更新資料庫。
                    entity.Name = model.Name;
                    entity.Price = model.Price; 
                }          
                
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

            }
        }

        /// <summary> 刪除 </summary>
        /// <param name="id">模型id</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            //寫法1
            //資料異動如果出問題此SQL交易則取消(RollbackAsync)
            await using (var transaction = await context.Database.BeginTransactionAsync())
            {
                var entity = await context.ProductInfos.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (entity == null)
                {
                    throw new InvalidDataException("找不到該筆資料");
                }

                // 刪除實體
                context.ProductInfos.Remove(entity);

                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            return true;
        }
    }
}

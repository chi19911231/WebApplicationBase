using Microsoft.EntityFrameworkCore;
using WebApplicationBase.Models.Entities;
using WebApplicationBase.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace WebApplicationBase.Services
{

    /// <summary> 主頁 Interface </summary>
    public interface IBaseTableService
    {
        /// <summary> 取得單一資料 </summary>
        /// <param name="id">模型id</param>
        /// <returns></returns>
        Task<FvmBaseModel.VM_Data> GetAsync(int id);

        /// <summary> 新增、更新 </summary>
        /// <param name="model">新增、更新 模型</param>
        /// <returns></returns>
        Task UpdateAsync(FvmBaseModel.VM_Data model);

    }

    /// <summary> 主頁 Service </summary>
    public class BaseTableService: IBaseTableService
    {
        private readonly WebApplicationBaseContext context;

        public BaseTableService(WebApplicationBaseContext context)
        {
            this.context = context;
        }        
                   
        public async Task<FvmBaseModel.VM_Data> GetAsync(int id)
        {
            var model = await (from baseTables in context.BaseTables
                               where baseTables.Id == id
                               select new FvmBaseModel.VM_Data
                               {
                                   ID = baseTables.Id,
                                   Title = baseTables.Title,
                                   Content = baseTables.Content,
                               }).FirstOrDefaultAsync();

            if (model == null)
            {                
                throw new InvalidDataException("找不到該筆資料");
            }

            return model;

        }

        /// <summary> 新增、更新 </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateAsync(FvmBaseModel.VM_Data model) 
        {
            //寫法1
            //資料異動如果出問題此SQL交易則取消(RollbackAsync)
            await using (var transaction = await context.Database.BeginTransactionAsync())
            {

                if (model.ID == 0)
                {
                    var baseTable = new BaseTable()
                    {
                        Title = model.Title,
                        Content = model.Content,
                    };

                    await context.BaseTables.AddAsync(baseTable);

                }
                else
                {
                    var entity = await context.BaseTables.Where(x => x.Id == model.ID).FirstOrDefaultAsync();

                    if (entity == null)
                    {
                        throw new InvalidDataException("找不到該筆資料");
                    }

                    //因Entity Framework Core會自動追蹤實體的變更，不用呼叫Update() ，呼叫 SaveChangesAsync()會自動更新資料庫。
                    entity.Content = model.Content;
                    entity.Title = model.Title;

                }

                await context.SaveChangesAsync();
                await transaction.CommitAsync();

            }

            ////舊寫法
            ////風險高，可能發生資料異常問題
            //var baseTable = new BaseTable()
            //{
            //    Title = model.Title,
            //    Content = model.Content,
            //};
            //await context.BaseTables.AddAsync(baseTable);
            //await context.SaveChangesAsync();

        }
    }
}
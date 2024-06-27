using Microsoft.EntityFrameworkCore;
using WebApplicationBase.Models.Entities;
using WebApplicationBase.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace WebApplicationBase.Services
{

    /// <summary> 主頁 Interface </summary>
    public interface IBaseTableService
    {        
        /// <summary> 新增、更新 </summary>
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
    
        /// <summary> 新增、更新 </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateAsync(FvmBaseModel.VM_Data model) 
        {

            //寫法1
            //資料異動如果出問題此SQL交易則取消(RollbackAsync)
            await using (var transaction = await context.Database.BeginTransactionAsync())
            {
                model.ID = 16;

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

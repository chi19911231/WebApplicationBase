using WebApplicationBase.ViewModels;

namespace WebApplicationBase.Services
{
    /// <summary>
    /// 主頁 Interface
    /// </summary>
    public interface IHomeService
    {
        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        IQueryable<FvmHome.VM_Data> GetSearchList();
        //在資料被列舉前的LINQ查詢方法的類別會是IQueryable，允許被調整為各式各樣的SQL語句。
        //而在資料被列舉後的LINQ查詢方法的類別會是IEnumerable，此時資料已存放在記憶體，不會再拼湊任何SQL語句。

        /// <summary> 取得單一資料 </summary>
        /// <param name="id">模型id</param>
        /// <returns></returns>
        Task<FvmHome.VM_Data> GetAsync(int id);

        /// <summary> 更新商品 </summary>
        /// <param name="model">更新模型</param>
        /// <returns></returns>
        Task UpdateAsync(FvmHome.VM_Data model);

        /// <summary> 刪除 </summary>
        /// <param name="id">模型id</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

    }

    /// <summary>
    /// 主頁 Service
    /// </summary>
    public class HomeService : IHomeService
    {
        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        public IQueryable<FvmHome.VM_Data> GetSearchList() 
        {                    
            var model = new FvmHome.VM_Data()
            {
                ID = 1,
                Title = "Title",
                Content = "Content",
            };
            
            return null;
        }

        /// <summary> 取得單一資料 </summary>
        /// <param name="id">模型id</param>
        /// <returns></returns>
        public async Task<FvmHome.VM_Data> GetAsync(int id)
        {
            var model = new FvmHome.VM_Data()
            {
                ID = id,
                Title = "Title",
                Content = "Content",               
            };           

            return model;
        }

        /// <summary> 更新商品 </summary>
        /// <param name="model">更新模型</param>
        /// <returns></returns>
        public Task UpdateAsync(FvmHome.VM_Data model)
        {

            return null;
        }

        /// <summary> 刪除 </summary>
        /// <param name="id">模型id</param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(int id)
        {

            return null;
        }
    }
}

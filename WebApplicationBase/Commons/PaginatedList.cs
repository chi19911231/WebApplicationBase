using Microsoft.EntityFrameworkCore;

namespace WebApplicationBase.Commons
{
    public class PaginatedList<T> : List<T>
    {

        #region 頁數設定        

        /// <summary> 頁數 </summary>
        public int PageIndex { get; private set; }

        /// <summary> 總頁數 </summary>
        public int TotalPages { get; private set; }

        /// <summary> 上一頁 </summary>
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        /// <summary> 下一頁 </summary>
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        #endregion
   
        /// <summary> 建構子 </summary>
        /// <param name="items">資料</param>
        /// <param name="count">資料總比數</param>
        /// <param name="pageIndex">頁數</param>
        /// <param name="pageSize">每頁幾筆</param>
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {

            //目前頁數
            PageIndex = pageIndex;
            
            //總頁數
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            //分頁資料
            this.AddRange(items);

        }

        /// <summary> 分頁資料 </summary>
        /// <param name="source">資料來源</param>
        /// <param name="pageIndex">頁數</param>
        /// <param name="pageSize">每頁幾筆</param>
        /// <returns></returns>
        public static async Task<PaginatedList<T>> ListPageAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {

            //總比數
            var count = await source.CountAsync();

            //分頁資料
            var data = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            //分頁相關設定
            var listData = new PaginatedList<T>(data, count, pageIndex, pageSize);

            return listData;
        }

    }
}

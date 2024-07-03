namespace WebApplicationBase.ViewModels.Base
{

    /// <summary> 分頁 模型 </summary>
    public class VM_Page
    {
        /// <summary> 目前頁數 </summary>
        public int PageIndex { get; set; }

        /// <summary> 總頁數 </summary>
        public int PagesTotal { get; set; }

        /// <summary> 每頁幾筆 (預設10筆) </summary>
        public int PageSize { get; set; } = 10;

        /// <summary> 頁數 </summary>
        public int? PageNumber { get; set; }

        /// <summary> 移至第幾頁 </summary>
        public int? GoToPageNumber { get; set; }

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
                return (PageIndex < PagesTotal);
            }
        }

    }

}

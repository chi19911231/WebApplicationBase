using WebApplicationBase.Commons;
using WebApplicationBase.ViewModels.Base;

namespace WebApplicationBase.ViewModels
{
    /// <summary> 範本 </summary>
    public class FvmBasePage
    {
        /// <summary> 範本(分頁) 模型 </summary>
        public class VM_PageData : VM_Page
        {
            /// <summary> ID </summary>
            public int ID { get; set; }

            public PaginatedList<VM_Data>? ListData { get; set; }

        }

        /// <summary> 範本(基本) 模型 </summary>
        public class VM_Data
        {
            /// <summary> ID </summary>
            public int ID { get; set; }

            /// <summary> 標題 </summary>
            public string? Title { get; set; }

            /// <summary> 內容 </summary>
            public string? Content { get; set; }
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WebApplicationBase.Commons;
using WebApplicationBase.ViewModels.Base;

namespace WebApplicationBase.ViewModels
{
    public class FvmDynamic
    {
        /// <summary> 範本(分頁) 模型 </summary>
        public class VM_PageData : VM_Page
        {
            /// <summary> ID </summary>
            public int Id { get; set; }

            /// <summary> 列表資料(有分頁) </summary>
            public PaginatedList<VM_Data>? PageListData { get; set; }

            /// <summary> 列表資料(無分頁) </summary>
            public List<VM_Data>? ListData { get; set; }

        }
       

        /// <summary> 資料 模型 </summary>
        public class VM_Data
        {
            /// <summary> Id </summary>          
            public int Id { get; set; } = 0;

            /// <summary> 帳號 </summary>
            [Required(ErrorMessage = "帳號必填")]
            [DisplayName("帳號")]
            [MaxLength(20)]
            public string? Acount { get; set; }

            /// <summary> 密碼 </summary>
            [Required(ErrorMessage = "密碼必填")]
            [DisplayName("密碼")]
            [MaxLength(50)]
            [DataType(DataType.Password)]
            public string? Password { get; set; }

            /// <summary> 姓名 </summary>
            [Required(ErrorMessage = "姓名必填")]
            [DisplayName("姓名")]
            [MaxLength(15)]
            public string? Name { get; set; }

            /// <summary> 動態資料 </summary>
            public List<VM_DynamicData> ListDynamicData { get; set; } = new List<VM_DynamicData>();
            //public List<VM_DynamicData> ListDynamicData { get; set; } = new List<VM_DynamicData>
            //{
            //    new VM_DynamicData { DynamicId = 0 }
            //};
        }

        /// <summary> 動態 模型 </summary>
        public class VM_DynamicData
        {
            /// <summary> DynamicId </summary>
            public int DynamicId { get; set; }

            /// <summary> 地址 </summary>
            [Required(ErrorMessage = "地址必填")]
            [DisplayName("地址")]
            public string? Address { get; set; }
        }

    }
}

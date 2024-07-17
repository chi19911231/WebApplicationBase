using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using WebApplicationBase.Commons;
using WebApplicationBase.ViewModels.Base;

namespace WebApplicationBase.ViewModels
{
    public class FvmProductInfo
    {
        /// <summary> 範本(分頁) 模型 </summary>
        public class VM_PageData : VM_Page
        {
            /// <summary> ID </summary>
            public int Id { get; set; }
            public PaginatedList<VM_Data>? PageListData { get; set; }

            public List<VM_Data>? ListData { get; set; }

        }

        /// <summary> 單筆資料 模型 </summary>
        public class VM_Data
        {
            /// <summary> ID </summary>          
            public int Id { get; set; } = 0; 

            /// <summary> 名稱 </summary>
            //[Required(ErrorMessage = "名稱必填")]
            [DisplayName("名稱")]
            [MaxLength(15)]
            public string? Name { get; set; }

            //[Required(ErrorMessage = "價格必填")]
            [RegularExpression(@"^\d+$", ErrorMessage = "價格只能輸入數字")]
            [DisplayName("價格")]
            public decimal? Price { get; set; }

            //[Required(ErrorMessage = "種類必填")]
            //[DisplayName("種類")]
            //public int? Type { get; set; }
        }


        /// <summary> 自訂驗證 </summary>
        /// <param name="modelState"></param>
        public void OtherValidation(ModelStateDictionary modelState)
        {


        }


    }
}

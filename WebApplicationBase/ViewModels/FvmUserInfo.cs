using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplicationBase.Commons;
using WebApplicationBase.Enums;
using WebApplicationBase.ViewModels.Base;



namespace WebApplicationBase.ViewModels
{

    public class FvmUserInfo
    {
        /// <summary> 範本(分頁) 模型 </summary>
        public class VM_PageData : VM_Page
        {
            /// <summary> ID </summary>
            public int ID { get; set; }
            public PaginatedList<VM_Data>? PageListData { get; set; }

            public List<VM_Data>? ListData { get; set; }     

        }

        /// <summary> 使用者 模型 </summary>
        public class VM_Data
        {
            /// <summary> ID </summary>          
            public int? ID { get; set; }

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

            /// <summary> 身分證 </summary>
            [Required(ErrorMessage = "身分證必填")]
            [DisplayName("身分證")]
            [MaxLength(10)]
            public string? PersonId { get; set; }

            /// <summary> 性別(列舉值 1:男生 2:女生 3:其他) </summary>
            [Required(ErrorMessage = "性別必填")]
            [DisplayName("性別")]
            public int? Gender { get; set; }

            /// <summary> 電子信箱 </summary>
            [DisplayName("電子信箱")]
            [Required(ErrorMessage = "電子信箱必填")]
            [MaxLength(100, ErrorMessage = "電子信箱不能超過100個字")]
            [EmailAddress(ErrorMessage = "請輸入有效的電子信箱地址")]
            public string? Email { get; set; }

            /// <summary> 手機 </summary>
            [DisplayName("手機")]
            [Required(ErrorMessage = "手機必填")]
            [MaxLength(10)]
            [MinLength(10, ErrorMessage = "手機必須10碼")]
            [RegularExpression(@"^\d+$", ErrorMessage = "手機號碼只能輸入數字")]
            public string? Phone { get; set; }

            /// <summary> 地址 </summary>
            [Required(ErrorMessage = "地址必填")]
            [DisplayName("地址")]
            public string? Address { get; set; }

        }

        public void OtherValidation(ModelStateDictionary modelState)
        {


        }
        
    }
}

using System.ComponentModel;

namespace WebApplicationBase.Enums
{
    #region 系統底層相關設定
    /// <summary> 回傳結果列舉(成功、失敗) </summary>
    public enum StatusEnum
    {
        /// <summary> 成功 </summary>
        [Description("成功")] 
        Success = 1,

        /// <summary> 失敗 </summary>
        [Description("失敗")] 
        Fail = 2,
    }
    #endregion


    #region 系統相關設定
    /// <summary> 性別 列舉(男、女、其他) </summary>
    public enum GenderEnum
    {
        /// <summary> 男 </summary>
        [Description("男")]
        Male = 1,

        /// <summary> 女 </summary>
        [Description("女")]
        Female = 2,

        /// <summary> 其他 </summary>
        [Description("其他")]
        Other = 3,
    }






    #endregion





    public class EnumType
    {

       
    }
}

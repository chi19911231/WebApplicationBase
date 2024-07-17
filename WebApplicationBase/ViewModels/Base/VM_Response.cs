using WebApplicationBase.Enums;

namespace WebApplicationBase.ViewModels.Base
{

    public class VM_Response
    {
        /// <summary> 狀態(1:Success 2:Fail) </summary>
        public StatusEnum Status { get; set; }

        /// <summary> 訊息 </summary>
        public string Message { get; set; } = "";

        /// <summary> 資料 </summary>
        public object Data { get; set; } = "";


        /// <summary> 網址 </summary>
        public string Url { get; set; } = "";


        /// <summary> 設定訊息 </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public VM_Response SetMessage(string message)
        {
            Message = message;
            return this;
        }

        /// <summary> 設定資料 </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public VM_Response SetData(object data)
        {
            Data = data;
            return this;
        }

        /// <summary>
        /// 設定成功失敗狀態
        /// </summary>
        /// <returns></returns>
        public VM_Response SetStatus(StatusEnum status)
        {
            Status = status;
            return this;
        }

        ///// <summary> 設定成功 </summary>
        ///// <returns></returns>
        //public VM_Response SetSuccess()
        //{
        //    Status = StatusEnum.Success;
        //    return this;
        //}

        ///// <summary> 設定失敗 </summary>
        ///// <returns></returns>
        //public VM_Response SetFail()
        //{
        //    Status = StatusEnum.Fail;
        //    return this;
        //}    

    }
}

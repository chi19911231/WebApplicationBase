namespace WebApplicationBase.ViewModels.Base
{
    public class VM_Response
    {

        /// <summary> Message </summary>
        public string Message { get; set; }
        /// <summary> Data </summary>
        public object Data { get; set; }


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

    }
}

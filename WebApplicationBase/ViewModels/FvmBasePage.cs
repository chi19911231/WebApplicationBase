namespace WebApplicationBase.ViewModels
{
    public class FvmBasePage
    {

        /// <summary> 範本 模型 </summary>
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

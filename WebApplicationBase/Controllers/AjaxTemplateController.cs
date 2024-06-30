using Microsoft.AspNetCore.Mvc;
using WebApplicationBase.ViewModels.Base;

namespace WebApplicationBase.Controllers
{
    public class AjaxTemplateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Ajax Get、Post相關

        /// <summary> </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get_HttpGetPartialView()
        {
            return PartialView("_PartialHttpGet");
        }

        /// <summary> </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Get_HttpPostPartialView()
        {
            return PartialView("_PartialHttpPost");
        }

        /// <summary>  </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get_HttpGetParameterPartialView(int id)
        {
            return PartialView("_PartialHttpGetParameter");
        }

        /// <summary> </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Get_HttpPostParameterPartialView(int id)
        {
            return PartialView("_PartialHttpPostParameter");
        }

        /// <summary> </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get_HttpGetObjectPartialView([FromQuery] VM_Request model)
        {
            return PartialView("_PartialHttpGetObject");
        }

        /// <summary> </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Get_HttpPostObjectPartialView([FromBody] VM_Request model)
        {
            return PartialView("_PartialHttpPostObject");
        }

        /// <summary> </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get_HttpGetJson()
        {
            var data = new VM_Response();
            data.SetMessage("Message");
            data.SetData("Data");

            return Json(data);
        }

        /// <summary>  </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Get_HttpPostJson()
        {
            var data = new VM_Response();
            data.SetMessage("Message");
            data.SetData("Data");

            return Json(data);
        }

        /// <summary> </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get_HttpGetParameterJson(string id)
        {
            var data = new VM_Response();
            data.SetMessage("Message");
            data.SetData("Data");

            return Json(data);
        }

        /// <summary> </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Get_HttpPostParameterJson(string id)
        {
            var data = new VM_Response();
            data.SetMessage("Message");
            data.SetData("Data");

            return Json(data);
        }

        /// <summary> </summary>         
        /// <param name="model"></param>         
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get_HttpGetObjectJson([FromQuery] VM_Request model)
        {
            var data = new VM_Response();
            data.SetMessage(model.Message);
            data.SetData(model.Data);

            return Json(data);
        }

        /// <summary> </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Get_HttpPostObjectJson([FromBody] VM_Request model)
        {
            var data = new VM_Response();
            data.SetMessage(model.Message);
            data.SetData(model.Data);

            return Json(data);
        }

        #endregion


    }
}

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationBase.Models;
using WebApplicationBase.Services;
using WebApplicationBase.ViewModels.Base;

namespace WebApplicationBase.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeServicer;

        #region 建構子
        /// <summary> 建構子 </summary>
        /// <param name="logger"></param>
        /// <param name="homeService"></param>
        public HomeController(ILogger<HomeController> logger , IHomeService homeService)
        {
            _logger = logger;
            _homeServicer = homeService;
        }
        #endregion


        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        #region Ajax Get、Post相關

        /// <summary> </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetHttpGet()
        {
            return PartialView("_PartialGetHttpGet");
        }

        /// <summary> </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetHttpPost()
        {
            return PartialView("_PartialGetHttpPost");
        }

        /// <summary>  </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetHttpGetParameter(int id)
        {            
            return PartialView("_PartialGetHttpGetParameter");          
        }

        /// <summary> </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetHttpPostParameter(int id)
        {
            return PartialView("_PartialGetHttpPostParameter");
        }

        /// <summary>  </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetHttpGetObject([FromQuery] VM_Request model)
        {
            return PartialView("_PartialGetHttpGetObject");
        }

        /// <summary> </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetHttpPostObject([FromBody] VM_Request model)
        {
            return PartialView("_PartialGetHttpPostObject");
        }

        /// <summary> </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetHttpGetJson()
        {
            var data = new VM_Response();        
            data.SetMessage("Message");
            data.SetData("Data");

            return Json(data);
        }

        /// <summary>  </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetHttpPostJson()
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
        public IActionResult GetHttpGetParameterJson([FromQuery] string id)
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
        public IActionResult GetHttpPostParameterJson([FromBody] string id)
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
        public IActionResult GetHttpGetObjectJson([FromQuery] VM_Request model)
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
        public IActionResult GetHttpPostObjectJson([FromBody] VM_Request model)
        {           
            var data = new VM_Response();
            data.SetMessage(model.Message);
            data.SetData(model.Data);

            return Json(data);
        }
      
        #endregion


         /// <summary> 取得所有資料 </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetListData()
        {
            var model = _homeServicer.GetSearchList();            
            return View(model);
        }

        /// <summary> 取得單筆資料 </summary>
        /// <param name="id"> 資料編號 </param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetData(int id)
        {
            var model = await _homeServicer.GetAsync(id);
            return View(model);
        }

    }
}

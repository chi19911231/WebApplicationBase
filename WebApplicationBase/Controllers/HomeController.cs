using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationBase.Models;
using WebApplicationBase.Services;
using WebApplicationBase.ViewModels;

namespace WebApplicationBase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeServicer;

        #region 建構子
        /// <summary>
        /// 建構子
        /// </summary>
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

        [HttpGet]
        public IActionResult GetHttpGet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetHttpPost()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetHttpGetParameter(string id)
        {            
            return View();
        }

        [HttpPost]
        public IActionResult GetHttpPostParameter(int id)
        {            
            return View();
        }

        /// <summary> 取得所有資料 </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetListData()
        {
            var model = _homeServicer.GetSearchList();
            return View(model);
        }

        #endregion


        /// <summary> 取得單筆資料 </summary>
        /// <param name="id"> 資料編號 </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetData(int id)
        {
            var model = await _homeServicer.GetAsync(id);
            return View(model);
        }

    }
}

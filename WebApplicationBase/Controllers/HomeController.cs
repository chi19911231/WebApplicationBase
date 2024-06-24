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

        #region �غc�l
        /// <summary>
        /// �غc�l
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


        #region Ajax Get�BPost����

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

        /// <summary> ���o�Ҧ���� </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetListData()
        {
            var model = _homeServicer.GetSearchList();
            return View(model);
        }

        #endregion


        /// <summary> ���o�浧��� </summary>
        /// <param name="id"> ��ƽs�� </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetData(int id)
        {
            var model = await _homeServicer.GetAsync(id);
            return View(model);
        }

    }
}

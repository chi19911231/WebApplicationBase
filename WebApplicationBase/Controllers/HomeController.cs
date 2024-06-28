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
        private readonly IHomeService _homeService;

        #region �غc�l
        /// <summary> �غc�l </summary>
        /// <param name="logger"></param>
        /// <param name="homeService"></param>
        public HomeController(ILogger<HomeController> logger , IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
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



        /// <summary> ���o�Ҧ���� </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetListData()
        {
            var model = _homeService.GetSearchList();            
            return View(model);
        }

        /// <summary> ���o�浧��� </summary>
        /// <param name="id"> ��ƽs�� </param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetData(int id)
        {
            var model = await _homeService.GetAsync(id);
            return View(model);
        }

    }
}

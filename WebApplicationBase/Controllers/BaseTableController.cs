using Microsoft.AspNetCore.Mvc;
using WebApplicationBase.Services;
using WebApplicationBase.ViewModels;

namespace WebApplicationBase.Controllers
{
    public class BaseTableController : Controller
    {

        private readonly IBaseTableService _baseTableService;

        /// <summary> 建構子 </summary>
        public BaseTableController(IBaseTableService baseTableService) 
        {
            _baseTableService = baseTableService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model =  await _baseTableService.GetAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FvmBaseModel.VM_Data model)
        {
            await _baseTableService.UpdateAsync(model);
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

    }
}

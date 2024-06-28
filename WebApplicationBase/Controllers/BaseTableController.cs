using Microsoft.AspNetCore.Mvc;
using WebApplicationBase.Services;
using WebApplicationBase.ViewModels;
using WebApplicationBase.ViewModels.Base;

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


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _baseTableService.GetSearchListAsync();
            return View(model);
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


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _baseTableService.DeleteAsync(id);

            var data = new VM_Response();
            data.SetMessage("刪除");
            data.SetData("Data");

            return Json(data);
        }


 

    }
}

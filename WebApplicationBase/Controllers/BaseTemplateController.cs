using Microsoft.AspNetCore.Mvc;
using WebApplicationBase.Services;
using WebApplicationBase.ViewModels;
using WebApplicationBase.ViewModels.Base;

namespace WebApplicationBase.Controllers
{
    public class BaseTemplateController : Controller
    {
        private readonly IBaseTemplateService _baseTemplateService;

        /// <summary> 建構子 </summary>
        public BaseTemplateController(IBaseTemplateService baseTableService) 
        {
            _baseTemplateService = baseTableService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _baseTemplateService.GetSearchListAsync();
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
            var model =  await _baseTemplateService.GetAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FvmBaseModel.VM_Data model)
        {
            await _baseTemplateService.UpdateAsync(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _baseTemplateService.DeleteAsync(id);

            var data = new VM_Response();
            data.SetMessage("刪除");
            data.SetData("Data");

            return Json(data);
        }
    }
}

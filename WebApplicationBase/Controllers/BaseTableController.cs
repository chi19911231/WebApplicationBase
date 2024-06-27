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

        public IActionResult Create()
        {

            return View();
        }


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

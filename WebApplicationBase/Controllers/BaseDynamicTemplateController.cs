using Microsoft.AspNetCore.Mvc;
using WebApplicationBase.Commons;
using WebApplicationBase.Enums;
using WebApplicationBase.Services;
using WebApplicationBase.ViewModels;
using WebApplicationBase.ViewModels.Base;

namespace WebApplicationBase.Controllers
{
    public class BaseDynamicTemplateController : Controller
    {

        private readonly IBaseDynamicTemplateService _baseDynamicTemplateService;

        /// <summary> 建構子 </summary>
        public BaseDynamicTemplateController(IBaseDynamicTemplateService productInfoService)
        {
            _baseDynamicTemplateService = productInfoService;
        }

        /// <summary> </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index(FvmDynamic.VM_PageData searchModel)
        {

            var query = _baseDynamicTemplateService.GetSearchList();
            var data =  await PaginatedList<FvmDynamic.VM_Data>.ListPageAsync(query, searchModel.PageNumber ?? 1, searchModel.PageSize);

            var model = new FvmDynamic.VM_PageData()
            {
                PageIndex = data.PageIndex,
                PagesTotal = data.TotalPages,
                PageListData = data,
            };
            return View(model);
        }

        /// <summary> 新增 </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            var model = new FvmDynamic.VM_Data() { Id = 0 };
            return View("Update", model);
        }

        /// <summary> 編輯 </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _baseDynamicTemplateService.GetAsync(id);
            return View(model);
        }

        /// <summary> 新增、更新 </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(FvmDynamic.VM_Data model)
        {
            if (ModelState.IsValid)
            {
                await _baseDynamicTemplateService.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
            //return RedirectToAction("Index");
        }

        /// <summary> 刪除 </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = new VM_Response();
            try
            {
                if (ModelState.IsValid)
                {
                    await _baseDynamicTemplateService.DeleteAsync(id);
                    data.SetStatus(StatusEnum.Success);
                }
                else
                {
                    data.SetStatus(StatusEnum.Fail);
                }
            }
            catch (Exception ex)
            {
                data.Message = ex.Message;
                data.SetStatus(StatusEnum.Fail);
            }
            return Json(data);
        }

        /// <summary> 動態畫面 </summary>
        /// <returns></returns>
        public IActionResult Dynamic()
        {
            ViewData["index"] = 0;
            var model = new FvmDynamic.VM_Data();
            var dynamicModel = new FvmDynamic.VM_DynamicData() { DynamicId = 0 };
            model.ListDynamicData.Add(dynamicModel);
            //model.ListDynamicData = new List<FvmDynamic.VM_DynamicData>() { new FvmDynamic.VM_DynamicData() {  DynamicID = 0 } }; 

            return PartialView("_DynamicPartial", model);
        }

    }
}

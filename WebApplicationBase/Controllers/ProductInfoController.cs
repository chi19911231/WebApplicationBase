using Microsoft.AspNetCore.Mvc;
using WebApplicationBase.Commons;
using WebApplicationBase.Enums;
using WebApplicationBase.Services;
using WebApplicationBase.ViewModels;
using WebApplicationBase.ViewModels.Base;

namespace WebApplicationBase.Controllers
{
    public class ProductInfoController : Controller
    {
        private readonly IProductInfoService _productInfoService;

        /// <summary> 建構子 </summary>
        public ProductInfoController(IProductInfoService productInfoService)
        {
            _productInfoService = productInfoService;
        }

        /// <summary> 列表 </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(FvmProductInfo.VM_PageData searchModel)
        {
            var query = _productInfoService.GetSearchList();
            var data = await PaginatedList<FvmProductInfo.VM_Data>.ListPageAsync(query, searchModel.PageNumber ?? 1, searchModel.PageSize);

            var model = new FvmProductInfo.VM_PageData()
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
            var model = new FvmProductInfo.VM_Data();
            return PartialView("_UpdatePartial", model);
        }

        /// <summary> 編輯 </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model =  await _productInfoService.GetAsync(id);
            return PartialView("_UpdatePartial",model);
        }

        /// <summary> 更新 </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] FvmProductInfo.VM_Data model)
        {
            var data = new VM_Response();
            try
            {
                if (ModelState.IsValid)
                {
                    await _productInfoService.UpdateAsync(model);
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
            //await _productInfoService.UpdateAsync(model);
            //return PartialView("_UpdatePartial");
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
                    await _productInfoService.DeleteAsync(id);
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

    }
}

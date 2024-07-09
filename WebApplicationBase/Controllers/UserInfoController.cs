using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationBase.Commons;
using WebApplicationBase.Enums;
using WebApplicationBase.Services;
using WebApplicationBase.ViewModels;
using WebApplicationBase.ViewModels.Base;

namespace WebApplicationBase.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly IUserInfoService _userInfoService;

        /// <summary> 建構子 </summary>
        public UserInfoController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }


        /// <summary> 列表 </summary>
        public async Task<IActionResult> Index(FvmUserInfo.VM_PageData searchModel)
        {
            var query = _userInfoService.GetSearchList();
            var data = await PaginatedList<FvmUserInfo.VM_Data>.ListPageAsync(query, searchModel.PageNumber ?? 1, searchModel.PageSize);

            var model = new FvmUserInfo.VM_PageData()
            {              
                PageIndex = data.PageIndex,
                PagesTotal = data.TotalPages,
                PageListData = data,
            };

            return View(model);
        }

        public IActionResult Create()
        {
            return View("Update");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = await _userInfoService.GetAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FvmUserInfo.VM_Data model)
        {
            if (ModelState.IsValid)
            {
                await _userInfoService.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = new VM_Response();
            try            
            {
                var result = await _userInfoService.DeleteAsync(id);
                data.SetStatus(StatusEnum.Success);    
                return Json(data);
            } 
            catch (Exception ex) 
            {
                data.SetStatus(StatusEnum.Fail);
                data.SetMessage(ex.Message);
                return Json(data);
            }    
        }

    }
}

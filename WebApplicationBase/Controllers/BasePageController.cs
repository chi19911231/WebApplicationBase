using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationBase.Commons;
using WebApplicationBase.Models.Entities;
using WebApplicationBase.ViewModels;

namespace WebApplicationBase.Controllers
{
    public class BasePageController : Controller
    {
        private readonly WebApplicationBaseContext _context;

        public BasePageController(WebApplicationBaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(          
            string sortOrder,
            string currentFilterCustomer,
            string currentFilterNumber,
            string searchStringCustomer,
            string searchStringNumber,               
            int pageSize,
            int? goToPageNumber,         
            int? pageNumber)
        {
            // 1.搜尋邏輯
            var query = from baseTables in _context.BaseTables                    
                        select new FvmBasePage.VM_Data
                        {                             
                            ID = baseTables.Id ,                             
                            Title= baseTables.Title ,                             
                            Content= baseTables.Content ,
                        };


            //// 2.條件過濾
            //if (searchStringCustomer != null || searchStringNumber != null)
            //{
            //    pageNumber = 1;
            //}
            //else
            //{
            //    searchStringCustomer = currentFilterCustomer;
            //    searchStringNumber = currentFilterNumber;
            //}

            //ViewData["CurrentFilterCustomer"] = searchStringCustomer;
            //ViewData["CurrentFilterNumber"] = searchStringNumber;

            //if (!String.IsNullOrEmpty(searchStringCustomer))
            //{
            //    query = query.Where(s => s.CustomerName.Contains(searchStringCustomer));
            //}
            //if (!String.IsNullOrEmpty(searchStringNumber))
            //{
            //    query = query.Where(s => s.Number.Contains(searchStringNumber));
            //}

            //// 3.排序依據
            //ViewData["CurrentSort"] = sortOrder;

            //switch (sortOrder)
            //{
            //    case "1":
            //        query = query.OrderByDescending(s => s.ShippingDate);
            //        break;
            //    case "2":
            //        query = query.OrderBy(s => s.ShippingDate);
            //        break;
            //    case "3":
            //        query = query.OrderByDescending(s => s.Total);
            //        break;
            //    case "4":
            //        query = query.OrderBy(s => s.Total);
            //        break;
            //    default:
            //        query = query.OrderByDescending(s => s.ShippingDate);
            //        break;
            //}

            // 4.前往頁數
            if (goToPageNumber != null)
            {
                pageNumber = goToPageNumber;
            }

            // 5.每頁筆數
            if (pageSize == 0)
            {
                pageSize = 10;
            }
            ViewData["pageSize"] = pageSize;

            // 6.返回結果
            return View(await PaginatedList<FvmBasePage.VM_Data>.ListPageAsync(query.AsNoTracking(), pageNumber ?? 1, pageSize));
        }        
        public async Task<IActionResult> Index1(
            string sortOrder,
            string currentFilterCustomer,
            string currentFilterNumber,
            string searchStringCustomer,
            string searchStringNumber,
            int pageSize,
            int? goToPageNumber,
            int? pageNumber
            )
        
        {
            // 1.搜尋邏輯
            var query = from baseTables in _context.BaseTables
                        select new FvmBasePage1.VM_Data
                        {
                            ID = baseTables.Id,
                            Title = baseTables.Title,
                            Content = baseTables.Content,
                        };
            
            // 4.前往頁數
            if (goToPageNumber != null)
            {
                pageNumber = goToPageNumber;
            }

            // 5.每頁筆數
            if (pageSize == 0)
            {
                pageSize = 10;
            }


            var Data = await PaginatedList<FvmBasePage1.VM_Data>.ListPageAsync(query.AsNoTracking(), pageNumber ?? 1, pageSize);


            var model = new FvmBasePage1.VM_PageData()
            {
                ListData = Data,
                PagesTotal = Data.TotalPages,           
                PageIndex  = Data.PageIndex,
            };

            // 6.返回結果
            return View(model);
        }
        public async Task<IActionResult> Index2(FvmBasePage1.VM_PageData searchModel)
        {

            // 1.搜尋邏輯
            var query = from baseTables in _context.BaseTables
                        select new FvmBasePage1.VM_Data
                        {
                            ID = baseTables.Id,
                            Title = baseTables.Title,
                            Content = baseTables.Content,
                        };

            var Data = await PaginatedList<FvmBasePage1.VM_Data>.ListPageAsync(query.AsNoTracking(), searchModel.PageNumber ?? 1, searchModel.PageSize);

            var model = new FvmBasePage1.VM_PageData()
            {
                ListData = Data,
                PageIndex = Data.PageIndex,
                PagesTotal = Data.TotalPages,              
            };

            return View(model);
        }


    }
}

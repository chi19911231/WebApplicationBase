using Microsoft.AspNetCore.Mvc;

namespace WebApplicationBase.ViewComponents
{
    public class TopMenu : ViewComponent
    {       
        public TopMenu()
        {
            
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var items = await _context.Category.ToListAsync();
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace WebApplicationBase.ViewComponents
{
    public class FooterMenu : ViewComponent
    {
        public FooterMenu()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var items = await _context.Category.ToListAsync();
            return View();
        }
    }
}

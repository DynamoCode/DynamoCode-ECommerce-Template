using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Components
{
    public class NavbarViewComponent : ViewComponent
    {
        public NavbarViewComponent()
        { }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("_Navbar"));
        }
    }
}

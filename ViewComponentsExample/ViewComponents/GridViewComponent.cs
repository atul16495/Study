using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.ViewComponents
{
    //[ViewComponent]
    public class GridViewComponent : ViewComponent
    {
       public async Task<IViewComponentResult>InvokeAsync(PersonGridModel grid)
        {
            //ViewData["Grid"]=model;
            return View("Default", grid); // invoke a partila view Views/Shared/Component/Grid/Default.cshtml
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponenets.LayoutComponents
{
    public class _LayoutNavBarPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View();
        }
    }
}

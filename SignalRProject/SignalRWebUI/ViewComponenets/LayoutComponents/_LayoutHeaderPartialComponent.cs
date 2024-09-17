using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponenets.LayoutComponents
{
    public class _LayoutHeaderPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}

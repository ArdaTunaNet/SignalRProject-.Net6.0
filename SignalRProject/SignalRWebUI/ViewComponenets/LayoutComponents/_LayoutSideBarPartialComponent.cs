using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponenets.LayoutComponents
{
	public class _LayoutSideBarPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

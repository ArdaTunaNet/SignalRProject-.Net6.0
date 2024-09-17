using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponenets.LayoutComponents
{
	public class _LayoutFooterPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

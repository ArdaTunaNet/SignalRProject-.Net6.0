using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponenets.LayoutComponents
{
	public class _LayoutScriptPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

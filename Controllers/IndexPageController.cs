using Microsoft.AspNetCore.Mvc;

namespace SeminarieEnquete.Controllers
{
	[Route("")]
	public class IndexPageController : Controller
	{
		[Route("")]
		public IActionResult Get()
		{
			return View("Index");
		}
	}
}

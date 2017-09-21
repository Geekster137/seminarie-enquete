using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SeminarieEnquete.Controllers
{
	[Route("Admin")]
	public class AdminController : Controller
	{
		[Route("")]
		public async Task<IActionResult> Admin([FromQuery]string password)
		{
			if (password != "test")
				return View("Error");

			return View("Index");
		}
	}
}

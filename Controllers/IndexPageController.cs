using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SeminarieEnquete.Models;
using System.Linq;

namespace SeminarieEnquete.Controllers
{
	[Route("")]
	public class IndexPageController : Controller
	{
		private IMongoCollection<DbIp> _ipColl = DbConnection.Db.GetCollection<DbIp>("ips");

		[Route("")]
		public IActionResult Get()
		{
			var hasAlreadySubmitted = _ipColl.AsQueryable().Any(ip => ip.Id == HttpContext.Connection.RemoteIpAddress.ToString());

			if (hasAlreadySubmitted)
				return Redirect("/Finished");

			return View("Index");
		}

		[Route("Finished")]
		public IActionResult GetFinished()
		{
			return View("Finished");
		}
	}
}

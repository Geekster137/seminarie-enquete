using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SeminarieEnquete.Models;
using System.Threading.Tasks;

namespace SeminarieEnquete.Controllers
{
	[Route("api/forms")]
	public class FormController : Controller
	{
		private IMongoCollection<Form> _formsColl = DbConnection.Db.GetCollection<Form>("forms");
		private IMongoCollection<DbIp> _ipColl = DbConnection.Db.GetCollection<DbIp>("ips");

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var forms = await _formsColl.Find(f => true).ToListAsync();

			return Json(forms);
		}

		[HttpPost]
		public async Task PostForm([FromBody]Form data)
		{
			await _formsColl.InsertOneAsync(data);

			var remoteIp = HttpContext.Connection.RemoteIpAddress;
			var ipToInsert = new DbIp { Id = remoteIp.ToString() };

			await _ipColl.InsertOneAsync(ipToInsert);
		}
	}
}

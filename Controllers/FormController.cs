using Microsoft.AspNetCore.Mvc;
using MongoConnection;
using SeminarieEnquete.Models;
using System.Threading.Tasks;

namespace SeminarieEnquete.Controllers
{
	[Route("api/forms")]
	public class FormController : Controller
	{
		private MongoCollection<Form> _formsColl = new MongoCollection<Form>("forms");

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var forms = await _formsColl.FindAll();

			return Json(forms);
		}

		[HttpPost]
		public void PostForm([FromBody]Form data)
		{
			_formsColl.InsertOne(data);
		}
	}
}

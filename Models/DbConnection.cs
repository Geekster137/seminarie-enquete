using MongoDB.Driver;

namespace SeminarieEnquete.Models
{
	public static class DbConnection
	{
		private static string _url = "mongodb://Joren:seminariedb@ds143744.mlab.com:43744/seminarie-enquete";
		private static IMongoClient _client = new MongoClient(_url);

		public static IMongoDatabase Db => _client.GetDatabase("seminarie-enquete");
	}
}

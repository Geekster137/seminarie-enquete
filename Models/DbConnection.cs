using MongoDB.Driver;

namespace SeminarieEnquete.Models
{
	public static class DbConnection
	{
		private static IMongoClient _client = new MongoClient("mongodb://192.168.0.151:27017");
		public static IMongoDatabase Db => _client.GetDatabase("seminarie_enquete");
	}
}

using MongoDB.Bson.Serialization.Attributes;

namespace SeminarieEnquete.Models
{
	public class DbIp
	{
		[BsonElement("_id")]
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.String)]
		public string Id { get; set; }
	}
}

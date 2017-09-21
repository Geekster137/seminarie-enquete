using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SeminarieEnquete.Models
{
	public class Form
	{
		[BsonElement("_id")]
		[BsonId]
		[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("gender")]
		[BsonRepresentation(MongoDB.Bson.BsonType.String)]
		public Gender Gender { get; set; }

		[BsonElement("has_been_cyberbullied")]
		public bool? HasBeenCyberbullied { get; set; }

		[BsonElement("how_often")]
		public string HowOften { get; set; }
		
		[BsonElement("is_neccessary")]
		public bool? IsNeccessary { get; set; }

		[BsonElement("platforms")]
		public string[] Platforms { get; set; }

		[BsonElement("sexting_good")]
		public bool? SextingGood { get; set; }

		[BsonElement("uses_social_media")]
		public bool UsesSocialMedia { get; set; }

		[BsonElement("what_for")]
		public string[] WhatFor { get; set; }
	}

	[JsonConverter(typeof(StringEnumConverter))]
	public enum Gender
	{
		Man,
		Vrouw
	}
}

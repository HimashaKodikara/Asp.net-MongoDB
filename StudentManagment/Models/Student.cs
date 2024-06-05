
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace StudentManagment.Models
{
    [BsonIgnoreExtraElements]
    public class Student
    {
    [BsonId]//MonogoDB ID
    [BsonRepresentation(BsonType.ObjectId)] // convert mongodb type to .net data type
        public string ID { get; set; } = String.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;
        [BsonElement("graduated")]
        public bool IsGraduated {  get; set; }
        [BsonElement("courses")]
        public string[]? Courses { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; } = String.Empty;
        [BsonElement("age")]
        public int Age { get; set; }
    }
}

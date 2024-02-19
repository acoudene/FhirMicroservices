// Changelogs Date  | Author                | Description
// 2023-12-23       | Anthony Coudène       | Creation

namespace PatientManagement.Data.MongoDb.Entities;

// This commented part could be used to have benefits of mongo entity typing
//[BsonIgnoreExtraElements]
//[BsonDiscriminator("patient", Required = true, RootClass = true)]
//[BsonKnownTypes(typeof(PatientInheritedMongo))]
//public record PatientMongoBase : IIdentifierMongoEntity

[BsonIgnoreExtraElements]
public record PatientMongo : IIdentifierMongoEntity
{
  [BsonId]
  [BsonElement("_id")]
  [BsonRepresentation(representation: BsonType.ObjectId)]
  [BsonIgnoreIfDefault]
  public ObjectId ObjectId { get; set; }

  [BsonElement("uuid")]
  [BsonGuidRepresentation(GuidRepresentation.Standard)]
  public required Guid Id { get; set; }

  // TODO - EntityProperties - Fields to complete
}

// This commented part could be used to have benefits of mongo entity typing
// Example of inherited class
//[BsonIgnoreExtraElements]
//[BsonDiscriminator("patientInherited", Required = true)]
//public record PatientInheritedMongo : PatientMongoBase
//{
//}
// Changelogs Date  | Author                | Description
// 2023-12-23       | Anthony Coudène       | Creation

namespace PatientManagement.Data.MongoDb.Entities;

public static class PatientMongoEntityExtensions
{
  // This commented part could be used to have benefits of mongo entity typing
  //public static PatientMongoBase ToInheritedMongo(this PatientBase entity)
  //{
  //  switch (entity)
  //  {
  //    case PatientInherited inheritedEntity: return inheritedEntity.ToMongo();
  //    default:
  //      throw new NotImplementedException();
  //  }
  //}

  // This commented part could be used to have benefits of mongo entity typing
  //public static PatientBase ToInheritedEntity(this PatientMongoBase mongoEntity)
  //{
  //  switch (mongoEntity)
  //  {
  //    case PatientInheritedMongo inheritedMongo: return inheritedMongo.ToEntity();
  //    default:
  //      throw new NotImplementedException();
  //  }
  //}

  public static PatientMongo ToMongo(this Patient entity)
  {
    return new PatientMongo()
    {
      Id = entity.Id

      // TODO - EntityMapping - Business Entity to Mongo Entity to complete
    };
  }

  public static Patient ToEntity(this PatientMongo mongoEntity)
  {
    return new Patient()
    {
      Id = mongoEntity.Id

      // TODO - EntityMapping - Mongo Entity to Business Entity to complete
    };
  }
}

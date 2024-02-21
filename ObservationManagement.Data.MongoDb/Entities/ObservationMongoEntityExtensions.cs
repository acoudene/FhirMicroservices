// Changelogs Date  | Author                | Description
// 2023-12-23       | Anthony Coudène       | Creation

namespace ObservationManagement.Data.MongoDb.Entities;

public static class ObservationMongoEntityExtensions
{
  // This commented part could be used to have benefits of mongo entity typing
  //public static ObservationMongoBase ToInheritedMongo(this ObservationBase entity)
  //{
  //  switch (entity)
  //  {
  //    case ObservationInherited inheritedEntity: return inheritedEntity.ToMongo();
  //    default:
  //      throw new NotImplementedException();
  //  }
  //}

  // This commented part could be used to have benefits of mongo entity typing
  //public static ObservationBase ToInheritedEntity(this ObservationMongoBase mongoEntity)
  //{
  //  switch (mongoEntity)
  //  {
  //    case ObservationInheritedMongo inheritedMongo: return inheritedMongo.ToEntity();
  //    default:
  //      throw new NotImplementedException();
  //  }
  //}

  public static ObservationMongo ToMongo(this Observation entity)
  {
    return new ObservationMongo()
    {
      Id = entity.Id

      // TODO - EntityMapping - Business Entity to Mongo Entity to complete
    };
  }

  public static Observation ToEntity(this ObservationMongo mongoEntity)
  {
    return new Observation()
    {
      Id = mongoEntity.Id

      // TODO - EntityMapping - Mongo Entity to Business Entity to complete
    };
  }
}

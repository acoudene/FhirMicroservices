// Changelogs Date  | Author                | Description
// 2023-12-23       | Anthony Coudène       | Creation

namespace ObservationManagement.Api;

public static class ObservationDtoEntityExtensions
{
  // This commented part could be used to have benefits of json entity typing
  //public static ObservationDtoBase ToInheritedDto(this ObservationBase entity)
  //{
  //  switch (entity)
  //  {
  //    case ObservationInherited inheritedEntity: return inheritedEntity.ToDto();
  //    default:
  //      throw new NotImplementedException();
  //  }
  //}

  // This commented part could be used to have benefits of json entity typing
  //public static ObservationBase ToInheritedEntity(this ObservationDtoBase dto)
  //{
  //  switch (dto)
  //  {
  //    case ObservationInheritedDto inheritedDto: return inheritedDto.ToEntity();
  //    default:
  //      throw new NotImplementedException();
  //  }
  //}

  public static ObservationDto ToDto(this Observation entity)
  {
    return new ObservationDto()
    {
      Id = entity.Id

      // TODO - EntityMapping - Business Entity to Dto to complete
    };
  }

  public static Observation ToEntity(this ObservationDto dto)
  {
    return new Observation()
    {
      Id = dto.Id

      // TODO - EntityMapping - Dto to Business Entity to complete
    };
  }
}

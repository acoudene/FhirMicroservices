// Changelogs Date  | Author                | Description
// 2023-12-23       | Anthony Coudène       | Creation

namespace PatientManagement.Api;

public static class PatientDtoEntityExtensions
{
  // This commented part could be used to have benefits of json entity typing
  //public static PatientDtoBase ToInheritedDto(this PatientBase entity)
  //{
  //  switch (entity)
  //  {
  //    case PatientInherited inheritedEntity: return inheritedEntity.ToDto();
  //    default:
  //      throw new NotImplementedException();
  //  }
  //}

  // This commented part could be used to have benefits of json entity typing
  //public static PatientBase ToInheritedEntity(this PatientDtoBase dto)
  //{
  //  switch (dto)
  //  {
  //    case PatientInheritedDto inheritedDto: return inheritedDto.ToEntity();
  //    default:
  //      throw new NotImplementedException();
  //  }
  //}

  public static PatientDto ToDto(this Patient entity)
  {
    return new PatientDto()
    {
      Id = entity.Id

      // TODO - EntityMapping - Business Entity to Dto to complete
    };
  }

  public static Patient ToEntity(this PatientDto dto)
  {
    return new Patient()
    {
      Id = dto.Id

      // TODO - EntityMapping - Dto to Business Entity to complete
    };
  }
}

// Changelogs Date  | Author                | Description
// 2023-12-23       | Anthony Coudène       | Creation

namespace PatientManagement.Dtos;

// This commented part could be used to have benefits of json entity typing
//[JsonPolymorphic]
//[JsonDerivedType(typeof(PatientInheritedDto), PatientInheritedDto.TypeId)]
public record PatientDto : IIdentifierDto
{
  public required Guid Id { get; set; }

  // TODO - EntityProperties - Fields to complete
}

// This commented part could be used to have benefits of json entity typing
// Example of inherited class
//[JsonDerivedType(typeof(PatientInheritedDto), PatientInheritedDto.TypeId)]
//public record PatientInheritedDto : PatientDtoBase
//{
//  public const string TypeId = "patient.patientInherited";
//}
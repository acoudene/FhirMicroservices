// Changelogs Date  | Author                | Description
// 2023-12-23       | Anthony Coudène       | Creation

namespace ObservationManagement.Dtos;

// This commented part could be used to have benefits of json entity typing
//[JsonPolymorphic]
//[JsonDerivedType(typeof(ObservationInheritedDto), ObservationInheritedDto.TypeId)]
public record ObservationDto : IIdentifierDto
{
  public required Guid Id { get; set; }

  // TODO - EntityProperties - Fields to complete
}

// This commented part could be used to have benefits of json entity typing
// Example of inherited class
//[JsonDerivedType(typeof(ObservationInheritedDto), ObservationInheritedDto.TypeId)]
//public record ObservationInheritedDto : ObservationDtoBase
//{
//  public const string TypeId = "observation.observationInherited";
//}
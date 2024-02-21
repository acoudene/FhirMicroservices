// Changelogs Date  | Author                | Description
// 2023-12-23       | Anthony Coudène       | Creation

namespace ObservationManagement.Data.Entities;

// This commented part could be used to have benefits of entity typing
//public abstract record ObservationBase : IIdentifierEntity

public record Observation : IIdentifierEntity
{
  public required Guid Id { get; set; }

  // TODO - EntityProperties - Fields to complete
}

// This commented part could be used to have benefits of entity typing
// Example of inherited class
//public record ObservationInherited : ObservationBase
//{
//}
// Changelogs Date  | Author                | Description
// 2023-12-23       | Anthony Coudène       | Creation

namespace PatientManagement.Data.Entities;

// This commented part could be used to have benefits of entity typing
//public abstract record PatientBase : IIdentifierEntity

public record Patient : IIdentifierEntity
{
  public required Guid Id { get; set; }

  // TODO - EntityProperties - Fields to complete
}

// This commented part could be used to have benefits of entity typing
// Example of inherited class
//public record PatientInherited : PatientBase
//{
//}
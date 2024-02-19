using System.Collections;

namespace PatientManagement.Host.Tests;

internal class PatientData : IEnumerable<object[]>
{
  public IEnumerator<object[]> GetEnumerator()
  {
    yield return new object[] 
    {
      new PatientDto()
      {
        Id = Guid.NewGuid()
        // TODO - EntityProperties - Fields to complete
      }
    };
    yield return new object[]
    {
      new PatientDto()
      {
        Id = Guid.NewGuid()
        // TODO - EntityProperties - Fields to complete
      }
    };
    yield return new object[]
    {
      new PatientDto()
      {
        Id = Guid.NewGuid()
        // TODO - EntityProperties - Fields to complete
      }
    };
  }
  
  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}


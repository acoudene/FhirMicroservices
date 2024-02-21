using System.Collections;

namespace ObservationManagement.Host.Tests;

internal class ObservationData : IEnumerable<object[]>
{
  public IEnumerator<object[]> GetEnumerator()
  {
    yield return new object[] 
    {
      new ObservationDto()
      {
        Id = Guid.NewGuid()
        // TODO - EntityProperties - Fields to complete
      }
    };
    yield return new object[]
    {
      new ObservationDto()
      {
        Id = Guid.NewGuid()
        // TODO - EntityProperties - Fields to complete
      }
    };
    yield return new object[]
    {
      new ObservationDto()
      {
        Id = Guid.NewGuid()
        // TODO - EntityProperties - Fields to complete
      }
    };
  }
  
  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}


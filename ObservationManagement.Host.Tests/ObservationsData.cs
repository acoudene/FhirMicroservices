using System.Collections;

namespace ObservationManagement.Host.Tests;

internal class ObservationsData : IEnumerable<object[]>
{
  public IEnumerator<object[]> GetEnumerator()
  {
    yield return new object[]
    {
      new List<ObservationDto>()
      {
        new ObservationDto()
        {
          Id = Guid.NewGuid()
          // TODO - EntityProperties - Fields to complete
        },
        new ObservationDto()
        {
          Id = Guid.NewGuid()
          // TODO - EntityProperties - Fields to complete
        }
      }
    };
    yield return new object[]
    {
      new List<ObservationDto>()
      {
        new ObservationDto()
        {
          Id = Guid.NewGuid()
          // TODO - EntityProperties - Fields to complete
        },
        new ObservationDto()
        {
          Id = Guid.NewGuid()
          // TODO - EntityProperties - Fields to complete
        }
      }
    };
    yield return new object[]
    {
      new List<ObservationDto>()
      {
        new ObservationDto()
        {
          Id = Guid.NewGuid()
          // TODO - EntityProperties - Fields to complete
        },
        new ObservationDto()
        {
          Id = Guid.NewGuid()
          // TODO - EntityProperties - Fields to complete
        }
      }
    };
  }
  
  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}


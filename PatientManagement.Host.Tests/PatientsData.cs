using System.Collections;

namespace PatientManagement.Host.Tests;

internal class PatientsData : IEnumerable<object[]>
{
  public IEnumerator<object[]> GetEnumerator()
  {
    yield return new object[]
    {
      new List<PatientDto>()
      {
        new PatientDto()
        {
          Id = Guid.NewGuid()
          // TODO - EntityProperties - Fields to complete
        },
        new PatientDto()
        {
          Id = Guid.NewGuid()
          // TODO - EntityProperties - Fields to complete
        }
      }
    };
    yield return new object[]
    {
      new List<PatientDto>()
      {
        new PatientDto()
        {
          Id = Guid.NewGuid()
          // TODO - EntityProperties - Fields to complete
        },
        new PatientDto()
        {
          Id = Guid.NewGuid()
          // TODO - EntityProperties - Fields to complete
        }
      }
    };
    yield return new object[]
    {
      new List<PatientDto>()
      {
        new PatientDto()
        {
          Id = Guid.NewGuid()
          // TODO - EntityProperties - Fields to complete
        },
        new PatientDto()
        {
          Id = Guid.NewGuid()
          // TODO - EntityProperties - Fields to complete
        }
      }
    };
  }
  
  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}


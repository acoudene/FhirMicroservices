// Changelogs Date  | Author                | Description
// 2023-12-23       | Anthony Coudène       | Creation

using System.Linq.Expressions;

namespace PatientManagement.Data.MongoDb.Repositories;

public class PatientRepository : IPatientRepository
{
  public const string CollectionName = "patient";

  protected MongoRepositoryComponent<Patient, PatientMongo> MongoRepositoryComponent { get => _mongoRepositoryComponent; }
  private readonly MongoRepositoryComponent<Patient, PatientMongo> _mongoRepositoryComponent;

  public PatientRepository(IMongoContext mongoContext)
  {
    _mongoRepositoryComponent = new MongoRepositoryComponent<Patient, PatientMongo>(mongoContext, CollectionName);
    _mongoRepositoryComponent.SetUniqueIndex(entity => entity.Id);
  }

  // This commented part could be used to have benefits of mongo entity typing
  //protected virtual PatientBase ToEntity(PatientMongoBase mongoEntity)
  //{
  //  return mongoEntity.ToInheritedEntity();
  //}

  // This commented part could be used to have benefits of mongo entity typing
  //protected virtual PatientMongoBase ToMongoEntity(PatientBase entity)
  //{
  //  return entity.ToInheritedMongo();
  //}

  protected virtual Patient ToEntity(PatientMongo mongoEntity)
  {
    return mongoEntity.ToEntity();
  }

  protected virtual PatientMongo ToMongoEntity(Patient entity)
  {
    return entity.ToMongo();
  }

  public virtual async Task<List<Patient>> GetAllAsync() => await _mongoRepositoryComponent.GetAllAsync(ToEntity);

  public virtual async Task<Patient?> GetByIdAsync(Guid id) => await _mongoRepositoryComponent.GetByIdAsync(id, ToEntity);

  public virtual async Task<List<Patient>> GetByIdsAsync(List<Guid> ids) => await _mongoRepositoryComponent.GetByIdsAsync(ids, ToEntity);

  public virtual async Task CreateAsync(Patient newItem) => await _mongoRepositoryComponent.CreateAsync(newItem, ToMongoEntity);

  public virtual async Task UpdateAsync(Patient updatedItem) => await _mongoRepositoryComponent.UpdateAsync(updatedItem, ToMongoEntity);

  public virtual async Task RemoveAsync(Guid id) => await _mongoRepositoryComponent.RemoveAsync(id);

  public virtual void SetUniqueIndex(Expression<Func<PatientMongo, object>> field) => _mongoRepositoryComponent.SetUniqueIndex(field);
}

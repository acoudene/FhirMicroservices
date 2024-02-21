// Changelogs Date  | Author                | Description
// 2023-12-23       | Anthony Coudène       | Creation

using System.Linq.Expressions;

namespace ObservationManagement.Data.MongoDb.Repositories;

public class ObservationRepository : IObservationRepository
{
  public const string CollectionName = "observation";

  protected MongoRepositoryComponent<Observation, ObservationMongo> MongoRepositoryComponent { get => _mongoRepositoryComponent; }
  private readonly MongoRepositoryComponent<Observation, ObservationMongo> _mongoRepositoryComponent;

  public ObservationRepository(IMongoContext mongoContext)
  {
    _mongoRepositoryComponent = new MongoRepositoryComponent<Observation, ObservationMongo>(mongoContext, CollectionName);
    _mongoRepositoryComponent.SetUniqueIndex(entity => entity.Id);
  }

  // This commented part could be used to have benefits of mongo entity typing
  //protected virtual ObservationBase ToEntity(ObservationMongoBase mongoEntity)
  //{
  //  return mongoEntity.ToInheritedEntity();
  //}

  // This commented part could be used to have benefits of mongo entity typing
  //protected virtual ObservationMongoBase ToMongoEntity(ObservationBase entity)
  //{
  //  return entity.ToInheritedMongo();
  //}

  protected virtual Observation ToEntity(ObservationMongo mongoEntity)
  {
    return mongoEntity.ToEntity();
  }

  protected virtual ObservationMongo ToMongoEntity(Observation entity)
  {
    return entity.ToMongo();
  }

  public virtual async Task<List<Observation>> GetAllAsync() => await _mongoRepositoryComponent.GetAllAsync(ToEntity);

  public virtual async Task<Observation?> GetByIdAsync(Guid id) => await _mongoRepositoryComponent.GetByIdAsync(id, ToEntity);

  public virtual async Task<List<Observation>> GetByIdsAsync(List<Guid> ids) => await _mongoRepositoryComponent.GetByIdsAsync(ids, ToEntity);

  public virtual async Task CreateAsync(Observation newItem) => await _mongoRepositoryComponent.CreateAsync(newItem, ToMongoEntity);

  public virtual async Task UpdateAsync(Observation updatedItem) => await _mongoRepositoryComponent.UpdateAsync(updatedItem, ToMongoEntity);

  public virtual async Task RemoveAsync(Guid id) => await _mongoRepositoryComponent.RemoveAsync(id);

  public virtual void SetUniqueIndex(Expression<Func<ObservationMongo, object>> field) => _mongoRepositoryComponent.SetUniqueIndex(field);
}

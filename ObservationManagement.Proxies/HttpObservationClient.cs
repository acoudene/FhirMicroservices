// Changelogs Date  | Author                | Description
// 2023-12-23       | Anthony Coudène       | Creation

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace ObservationManagement.Proxies;

public class HttpObservationClient : IObservationClient
{
  private readonly ILogger<HttpObservationClient> _logger;

  protected HttpRestClientComponent<ObservationDto> HttpRestClientComponent { get => _httpRestClientComponent; }
  private readonly HttpRestClientComponent<ObservationDto> _httpRestClientComponent;

  /// <summary>
  /// Constructor
  /// </summary>
  /// <param name="logger"></param>
  /// <param name="httpClientFactory"></param>
  /// <exception cref="ArgumentNullException"></exception>
  public HttpObservationClient(ILogger<HttpObservationClient> logger, IHttpClientFactory httpClientFactory)
  {
    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    _httpRestClientComponent = new HttpRestClientComponent<ObservationDto>(httpClientFactory);
  }

  public const string ConfigurationName = nameof(HttpObservationClient);

  public virtual string GetConfigurationName() => ConfigurationName;

  public virtual async Task<List<ObservationDto>> GetAllAsync(CancellationToken cancellationToken = default)
  {
    _logger.LogDebug("Processing remote call to {Method}...", nameof(GetAllAsync));

    return await _httpRestClientComponent.GetAllAsync(GetConfigurationName(), cancellationToken);
  }

  public virtual async Task<ObservationDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
  {
    _logger.LogDebug("Processing remote call to {Method}({Id})...", nameof(GetByIdAsync), id);

    return await _httpRestClientComponent.GetByIdAsync(id, GetConfigurationName(), cancellationToken);
  }

  public virtual async Task<List<ObservationDto>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default)
  {
    _logger.LogDebug("Processing remote call to {Method}({Ids})...", nameof(GetByIdsAsync), string.Join(',', ids));

    return await _httpRestClientComponent.GetByIdsAsync(ids, GetConfigurationName(), cancellationToken);
  }

  public virtual async Task CreateAsync(
    ObservationDto dto,
    CancellationToken cancellationToken = default)
  {
    _logger.LogDebug("Processing remote call to {Method}({Dto})...", nameof(CreateAsync), dto);

        await _httpRestClientComponent.CreateAsync(dto, GetConfigurationName(), true, cancellationToken);
  }

  public virtual async Task UpdateAsync(
    Guid id,
    ObservationDto dto,
    CancellationToken cancellationToken = default)
  {
    _logger.LogDebug("Processing remote call to {Method}({Id},{Dto})...", nameof(UpdateAsync), id, dto);

        await _httpRestClientComponent.UpdateAsync(id, dto, GetConfigurationName(), true, cancellationToken);
  }

  public virtual async Task<ObservationDto> DeleteAsync(
    Guid id,
    CancellationToken cancellationToken = default)
  {
    _logger.LogDebug("Processing remote call to {Method}({Id})...", nameof(DeleteAsync), id);

    return await _httpRestClientComponent.DeleteAsync(id, GetConfigurationName(), cancellationToken);
  }

  public virtual async Task PatchAsync(
    Guid id,
    JsonPatchDocument<ObservationDto> patch,    
    CancellationToken cancellationToken = default)
  {
    _logger.LogDebug("Processing remote call to {Method}({Id},{Patch})...", nameof(PatchAsync), id, patch);

        await _httpRestClientComponent.PatchAsync(id, patch, GetConfigurationName(), true, cancellationToken);
  }
}

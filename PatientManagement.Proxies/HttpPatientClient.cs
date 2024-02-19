// Changelogs Date  | Author                | Description
// 2023-12-23       | Anthony Coudène       | Creation

using Microsoft.AspNetCore.JsonPatch;

namespace PatientManagement.Proxies;

public class HttpPatientClient : IPatientClient
{
  protected HttpRestClientComponent<PatientDto> HttpRestClientComponent { get => _httpRestClientComponent; }

  private readonly HttpRestClientComponent<PatientDto> _httpRestClientComponent;

  /// <summary>
  /// Constructor
  /// </summary>
  /// <param name="httpClientFactory"></param>
  /// <exception cref="ArgumentNullException"></exception>
  public HttpPatientClient(IHttpClientFactory httpClientFactory)
  {
    _httpRestClientComponent = new HttpRestClientComponent<PatientDto>(httpClientFactory);
  }

  public const string ConfigurationName = nameof(HttpPatientClient);

  public virtual string GetConfigurationName() => ConfigurationName;

  public virtual async Task<List<PatientDto>> GetAllAsync(CancellationToken cancellationToken = default)
    => await _httpRestClientComponent.GetAllAsync(GetConfigurationName(), cancellationToken);

  public virtual async Task<PatientDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
      => await _httpRestClientComponent.GetByIdAsync(id, GetConfigurationName(), cancellationToken);

  public virtual async Task<List<PatientDto>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken = default)
      => await _httpRestClientComponent.GetByIdsAsync(ids, GetConfigurationName(), cancellationToken);

  public virtual async Task<HttpResponseMessage> CreateAsync(
    PatientDto dto,
    bool checkSuccessStatusCode = true,
    CancellationToken cancellationToken = default)
     => await _httpRestClientComponent.CreateAsync(dto, GetConfigurationName(), checkSuccessStatusCode, cancellationToken);

  public virtual async Task<HttpResponseMessage> UpdateAsync(
    Guid id,
    PatientDto dto,
    bool checkSuccessStatusCode = true,
    CancellationToken cancellationToken = default)
    => await _httpRestClientComponent.UpdateAsync(id, dto, GetConfigurationName(), checkSuccessStatusCode, cancellationToken);

  public virtual async Task<PatientDto> DeleteAsync(
    Guid id,
    CancellationToken cancellationToken = default)
    => await _httpRestClientComponent.DeleteAsync(id, GetConfigurationName(), cancellationToken);

  public virtual async Task<HttpResponseMessage> PatchAsync(
    Guid id,
    JsonPatchDocument<PatientDto> patch,
    bool checkSuccessStatusCode = true,
    CancellationToken cancellationToken = default)
    => await _httpRestClientComponent.PatchAsync(id, patch, GetConfigurationName(), checkSuccessStatusCode, cancellationToken);
}

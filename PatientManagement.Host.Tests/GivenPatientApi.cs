// Changelogs Date  | Author                | Description
// 2023-12-23       | Anthony Coudène       | Creation

namespace PatientManagement.Host.Tests;

/// WARNING - for the moment, I don't have found a solution to reset settings like connexion string on a static test server
/// So be careful when changing settings, the same first settings will remain for server for all tests in this class even if this container is reset.
/// For example, don't change default port to reuse the same.
public class GivenPatientApi : HostApiMongoTestBase<Program>
{
  public GivenPatientApi(
    WebApplicationFactory<Program> webApplicationFactory,
    ITestOutputHelper output)
    : base("patient", webApplicationFactory, output)
  {
  }

  private const string ApiPath = "/api";
  private const string ApiRelativePath = $"{ApiPath}/Patient/"; // Warning, this ending slash is important in HttpClientFactory... :(

  [Theory]
  [ClassData(typeof(PatientData))]
  public async Task WhenCreatingItem_ThenSingleItemIsCreated_Async(PatientDto item)
  {
    // Arrange
    var httpClientFactory = CreateHttpClientFactory(ApiRelativePath);
    var client = new HttpPatientClient(httpClientFactory);

    // Act
    HttpResponseMessage response = await client.CreateAsync(item, false);

    // Assert    
    Assert.Null(Record.Exception(() =>
    {
      if (!response.IsSuccessStatusCode)
        OutputHelper.WriteLine(response.Content.ReadAsStringAsync().Result);
      response.EnsureSuccessStatusCode();
    }));

    item = await client.GetByIdAsync(item.Id);
    Assert.NotNull(item);
  }

  [Theory]
  [ClassData(typeof(PatientsData))]
  public async Task WhenCreatingItems_ThenAllItemsAreGot_Async(List<PatientDto> items)
  {
    // Arrange
    var httpClientFactory = CreateHttpClientFactory(ApiRelativePath);
    var client = new HttpPatientClient(httpClientFactory);
    foreach (var item in items)
      await WhenCreatingItem_ThenSingleItemIsCreated_Async(item);
    var ids = items.Select(item => item.Id).ToList();
    int expectedCount = items.Count;

    // Act
    var gotItems = (await client.GetByIdsAsync(ids));

    // Assert
    Assert.True(items is not null && expectedCount == items.Count);
    Assert.Equivalent(items.Select(item => item.Id), gotItems.Select(item => item.Id));
  }

  [Theory]
  [ClassData(typeof(PatientsData))]
  public async Task WhenDeletingItems_ThenItemAreDeleted_Async(List<PatientDto> items)
  {
    // Arrange
    var httpClientFactory = CreateHttpClientFactory(ApiRelativePath);
    var client = new HttpPatientClient(httpClientFactory);
    foreach (var item in items)
      await WhenCreatingItem_ThenSingleItemIsCreated_Async(item);
    var ids = items.Select(item => item.Id).ToList();
    int expectedCount = items.Count;

    // Act
    foreach (Guid id in ids)
      await client.DeleteAsync(id);

    var gotItems = (await client.GetByIdsAsync(ids));

    // Assert    
    Assert.Empty(gotItems);    
  }

}

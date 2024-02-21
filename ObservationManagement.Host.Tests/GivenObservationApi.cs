// Changelogs Date  | Author                | Description
// 2023-12-23       | Anthony Coudène       | Creation

namespace ObservationManagement.Host.Tests;

/// WARNING - for the moment, I don't have found a solution to reset settings like connexion string on a static test server
/// So be careful when changing settings, the same first settings will remain for server for all tests in this class even if this container is reset.
/// For example, don't change default port to reuse the same.
public class GivenObservationApi : HostApiMongoTestBase<Program>
{
  public GivenObservationApi(
    WebApplicationFactory<Program> webApplicationFactory,
    ITestOutputHelper output)
    : base("observation", webApplicationFactory, output)
  {
  }

  private const string ApiPath = "/api";
  private const string ApiRelativePath = $"{ApiPath}/Observation/"; // Warning, this ending slash is important in HttpClientFactory... :(

  [Theory]
  [ClassData(typeof(ObservationData))]
  public async Task WhenCreatingItem_ThenSingleItemIsCreated_Async(ObservationDto item)
  {
    // Arrange
    var logger = CreateLogger<HttpObservationClient>();
    var httpClientFactory = CreateHttpClientFactory(ApiRelativePath);
    var client = new HttpObservationClient(logger, httpClientFactory);

    // Act
    await client.CreateAsync(item);

    // Assert      
    item = await client.GetByIdAsync(item.Id);
    Assert.NotNull(item);
  }

  [Theory]
  [ClassData(typeof(ObservationsData))]
  public async Task WhenCreatingItems_ThenAllItemsAreGot_Async(List<ObservationDto> items)
  {
    // Arrange
    var logger = CreateLogger<HttpObservationClient>();
    var httpClientFactory = CreateHttpClientFactory(ApiRelativePath);
    var client = new HttpObservationClient(logger,httpClientFactory);
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
  [ClassData(typeof(ObservationsData))]
  public async Task WhenDeletingItems_ThenItemAreDeleted_Async(List<ObservationDto> items)
  {
    // Arrange
    var logger = CreateLogger<HttpObservationClient>();
    var httpClientFactory = CreateHttpClientFactory(ApiRelativePath);
    var client = new HttpObservationClient(logger, httpClientFactory);
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

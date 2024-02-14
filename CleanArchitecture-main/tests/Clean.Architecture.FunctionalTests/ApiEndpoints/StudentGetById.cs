using Ardalis.HttpClientTestExtensions;
using Clean.Architecture.Infrastructure.Data;
using Clean.Architecture.Web.Endpoints.StudentEndpoints;
using Clean.Architecture.Web.StudentEndpoints;
using Xunit;

namespace Clean.Architecture.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class StudentGetById(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsSeedStudentGivenId1()
  {
    var result = await _client.GetAndDeserializeAsync<StudentRecord>(GetStudentByIdRequest.BuildRoute(1));

    Assert.Equal(1, result.Id);
    Assert.Equal(SeedData.S1.Name, result.Name);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenId1000()
  {
    string route = GetStudentByIdRequest.BuildRoute(1000);
    _ = await _client.GetAndEnsureNotFoundAsync(route);
  }
}

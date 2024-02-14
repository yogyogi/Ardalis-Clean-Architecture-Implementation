using Ardalis.HttpClientTestExtensions;
using Clean.Architecture.Infrastructure.Data;
using Clean.Architecture.Web.StudentEndpoints;
using Xunit;

namespace Clean.Architecture.FunctionalTests.ApiEndpoints;

[Collection("Sequential")]
public class StudentList(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client = factory.CreateClient();

  [Fact]
  public async Task ReturnsTwoStudents()
  {
    var result = await _client.GetAndDeserializeAsync<StudentListResponse>("/Student");

    Assert.Equal(2, result.Student.Count);
    Assert.Contains(result.Student, i => i.Name == SeedData.S1.Name);
    Assert.Contains(result.Student, i => i.Name == SeedData.S2.Name);
  }
}

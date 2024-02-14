using Clean.Architecture.Core.StudentAggregate;
using Xunit;

namespace Clean.Architecture.IntegrationTests.Data;
public class EfRepositoryStudentAdd : BaseEfRepoTestFixture
{
  [Fact]
  public async Task AddStudentAndSetsId()
  {
    var testStudentName = "testStudent";
    var testStudentStandard = "testStandard";
    var testStudentRank = 1;

    var repository = GetRepositoryStudent();
    var Student = new Student(testStudentName, testStudentStandard, testStudentRank);

    await repository.AddAsync(Student);

    var newStudent = (await repository.ListAsync()).FirstOrDefault();

    Assert.Equal(testStudentName, newStudent?.Name);
    Assert.Equal(testStudentStandard, newStudent?.Standard);
    Assert.Equal(testStudentRank, newStudent?.Rank);
    Assert.True(newStudent?.Id > 0);
  }
}

using Xunit;
using Clean.Architecture.Core.StudentAggregate;

namespace Clean.Architecture.IntegrationTests.Data;
public class EfRepositoryStudentDelete : BaseEfRepoTestFixture
{
  [Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    // add a Contributor
    var repository = GetRepositoryStudent();
    var initialName = "testName";
    var initialStandard = "testStandard";
    var initialRank = 1;

    var Student = new Student(initialName, initialStandard, initialRank);

    await repository.AddAsync(Student);

    // delete the item
    await repository.DeleteAsync(Student);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(),
        Contributor => Contributor.Name == initialName);
  }
}

using Microsoft.EntityFrameworkCore;
using Clean.Architecture.Core.StudentAggregate;
using Xunit;

namespace Clean.Architecture.IntegrationTests.Data;
public class EfRepositoryStudentUpdate : BaseEfRepoTestFixture
{
  [Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    // add a Student
    var repository = GetRepositoryStudent();
    var initialName = "testName";
    var initialStandard = "testStandard";
    var initialRank = 1;
    var Student = new Student(initialName, initialStandard, initialRank);

    await repository.AddAsync(Student);

    // detach the item so we get a different instance
    _dbContext.Entry(Student).State = EntityState.Detached;

    // fetch the item and update its title
    var newStudent = (await repository.ListAsync())
        .FirstOrDefault(a => a.Name == initialName);
    if (newStudent == null)
    {
      Assert.NotNull(newStudent);
      return;
    }

    Assert.NotSame(Student, newStudent);


    var newName = "testName2";
    var newStandard = "testStandard2";
    var newRank = 2;

    newStudent.UpdateStudent(newName, newStandard, newRank);

    // Update the item
    await repository.UpdateAsync(newStudent);

    // Fetch the updated item
    var updatedItem = (await repository.ListAsync())
        .FirstOrDefault(a => a.Name == newName);

    Assert.NotNull(updatedItem);
    Assert.NotEqual(Student.Name, updatedItem?.Name);
    Assert.NotEqual(Student.Standard, updatedItem?.Standard);
    Assert.NotEqual(Student.Rank, updatedItem?.Rank);

    Assert.Equal(newStudent.Id, updatedItem?.Id);


  }
}

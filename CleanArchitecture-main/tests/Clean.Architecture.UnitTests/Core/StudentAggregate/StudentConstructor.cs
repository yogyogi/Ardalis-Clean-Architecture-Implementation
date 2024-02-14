using Clean.Architecture.Core.StudentAggregate;
using Xunit;

namespace Clean.Architecture.UnitTests.Core.StudentAggregate;
public class StudentConstructor
{
  private readonly string _testName = "test name";
  private readonly string _testStandard = "test standard";
  private readonly int _testRank = 3;

  private Student? _testStudent;

  private Student CreateStudent()
  {
    return new Student(_testName, _testStandard, _testRank);
  }

  [Fact]
  public void InitializesName()
  {
    _testStudent = CreateStudent();

    Assert.Equal(_testName, _testStudent.Name);
    Assert.Equal(_testStandard, _testStudent.Standard);
    Assert.Equal(_testRank, _testStudent.Rank);
  }
}

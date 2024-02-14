using Ardalis.SharedKernel;
using FluentAssertions;
using NSubstitute;
using Clean.Architecture.UseCases.Student.Create;
using Xunit;

namespace Clean.Architecture.UnitTests.UseCases.Student;
public class CreateStudentHandlerHandle
{
  private readonly string _testName = "test name";
  private readonly string _testStandard = "test standard";
  private readonly int _testRank = 3;

  private readonly IRepository<Clean.Architecture.Core.StudentAggregate.Student> _repository = Substitute.For<IRepository<Clean.Architecture.Core.StudentAggregate.Student>>();
 
  private CreateStudentHandler _handler;

  public CreateStudentHandlerHandle()
  {
    _handler = new CreateStudentHandler(_repository);
  }

  private Clean.Architecture.Core.StudentAggregate.Student CreateStudent()
  {
    return new Clean.Architecture.Core.StudentAggregate.Student(_testName, _testStandard, _testRank);
  }

  [Fact]
  public async Task ReturnsSuccessGivenValidName()
  {
    _repository.AddAsync(Arg.Any<Clean.Architecture.Core.StudentAggregate.Student>(), Arg.Any<CancellationToken>())
      .Returns(Task.FromResult(CreateStudent()));
    var result = await _handler.Handle(new CreateStudentCommand(_testName, _testStandard, _testRank), CancellationToken.None);

    result.IsSuccess.Should().BeTrue();
  }
}

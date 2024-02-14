using Ardalis.SharedKernel;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Clean.Architecture.Core.Services;
using Clean.Architecture.Core.StudentAggregate;
using Xunit;

namespace Clean.Architecture.UnitTests.Core.Services;
public class DeleteStudentSevice_DeleteStudent
{
  private readonly IRepository<Student> _repository = Substitute.For<IRepository<Student>>();
  private readonly IMediator _mediator = Substitute.For<IMediator>();
  private readonly ILogger<DeleteStudentService> _logger = Substitute.For<ILogger<DeleteStudentService>>();

  private readonly DeleteStudentService _service;

  public DeleteStudentSevice_DeleteStudent()
  {
    _service = new DeleteStudentService(_repository, _mediator, _logger);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenCantFindStudent()
  {
    var result = await _service.DeleteStudent(0);

    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
  }
}

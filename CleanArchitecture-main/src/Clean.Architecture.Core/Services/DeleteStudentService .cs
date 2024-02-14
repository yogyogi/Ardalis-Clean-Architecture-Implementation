using Ardalis.Result;
using Ardalis.SharedKernel;
using MediatR;
using Microsoft.Extensions.Logging;
using Clean.Architecture.Core.StudentAggregate;
using Clean.Architecture.Core.StudentAggregate.Events;
using Clean.Architecture.Core.Interfaces;

namespace Clean.Architecture.Core.Services;
public class DeleteStudentService(IRepository<Student> _repository,
  IMediator _mediator,
  ILogger<DeleteStudentService> _logger) : IDeleteStudentService
{
  public async Task<Result> DeleteStudent(int studentId)
  {
    _logger.LogInformation("Deleting Student {studentId}", studentId);
    var aggregateToDelete = await _repository.GetByIdAsync(studentId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new StudentDeletedEvent(studentId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}

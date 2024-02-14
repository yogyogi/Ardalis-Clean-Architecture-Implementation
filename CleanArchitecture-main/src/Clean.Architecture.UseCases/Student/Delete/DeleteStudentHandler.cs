using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.Interfaces;

namespace Clean.Architecture.UseCases.Student.Delete;
public class DeleteStudentHandler(IDeleteStudentService _deleteStudentService)
  : ICommandHandler<DeleteStudentCommand, Result>
{
  public async Task<Result> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
  {
    return await _deleteStudentService.DeleteStudent(request.StudentId);
  }
}

using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Student.Update;
public class UpdateStudentHandler(IRepository<Core.StudentAggregate.Student> _repository)
  : ICommandHandler<UpdateStudentCommand, Result<StudentDTO>>
{
  public async Task<Result<StudentDTO>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
  {
    var existingStudent = await _repository.GetByIdAsync(request.StudentId, cancellationToken);
    if (existingStudent == null)
    {
      return Result.NotFound();
    }

    existingStudent.UpdateStudent(request.NewName!, request.Standard, request.Rank);

    await _repository.UpdateAsync(existingStudent, cancellationToken);

    return Result.Success(new StudentDTO(existingStudent.Id, existingStudent.Name, existingStudent.Standard, existingStudent.Rank));
  }
}


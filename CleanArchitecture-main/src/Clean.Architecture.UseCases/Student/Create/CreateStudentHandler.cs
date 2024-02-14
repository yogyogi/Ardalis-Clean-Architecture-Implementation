using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Student.Create;
public class CreateStudentHandler(IRepository<Core.StudentAggregate.Student> _repository)
  : ICommandHandler<CreateStudentCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateStudentCommand request,
    CancellationToken cancellationToken)
  {
    var newStudent = new Core.StudentAggregate.Student(request.Name, request.Standard, request.Rank);
    var createdItem = await _repository.AddAsync(newStudent, cancellationToken);

    return createdItem.Id;
  }
}

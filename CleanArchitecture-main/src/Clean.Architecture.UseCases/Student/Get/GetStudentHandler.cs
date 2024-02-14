using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.StudentAggregate.Specifications;

namespace Clean.Architecture.UseCases.Student.Get;
/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetStudentHandler(IReadRepository<Core.StudentAggregate.Student> _repository)
  : IQueryHandler<GetStudentQuery, Result<StudentDTO>>
{
  public async Task<Result<StudentDTO>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
  {
    var spec = new StudentByIdSpec(request.StudentId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new StudentDTO(entity.Id, entity.Name, entity.Standard, entity.Rank);
  }
}

using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Student.List;
public class ListStudentHandler(IListStudentQueryService _query)
  : IQueryHandler<ListStudentQuery, Result<IEnumerable<StudentDTO>>>
{
  public async Task<Result<IEnumerable<StudentDTO>>> Handle(ListStudentQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}


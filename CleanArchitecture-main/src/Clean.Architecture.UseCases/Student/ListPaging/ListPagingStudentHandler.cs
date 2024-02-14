using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.StudentAggregate.Specifications;

namespace Clean.Architecture.UseCases.Student.ListPaging;
/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class ListPagingStudentHandler(IReadRepository<Clean.Architecture.Core.StudentAggregate.Student> _repository)
  : IQueryHandler<ListPagingStudentQuery, Result<StudentPagingDTO>>
{
  public async Task<Result<StudentPagingDTO>> Handle(ListPagingStudentQuery request, CancellationToken cancellationToken)
  {
    var skip = request.RecordPerPage * (Convert.ToInt32(request.PageNo) - 1);

    var spec = new StudentByPagingSpec(skip, request.RecordPerPage);
    var count = await _repository.CountAsync();
    var entity = await _repository.ListAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    List<StudentDTO> sdList = entity.Select(p => new StudentDTO(p.Id, p.Name, p.Standard, p.Rank)).ToList();

    int totalPages = (int)Math.Ceiling((decimal)count / request.RecordPerPage);

    StudentPagingDTO s = new StudentPagingDTO(sdList, count, request.RecordPerPage, request.PageNo, totalPages);

    return s;
  }
}

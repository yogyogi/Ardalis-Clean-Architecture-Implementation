using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Student.ListPaging;
public record ListPagingStudentQuery(int PageNo, int RecordPerPage) : IQuery<Result<StudentPagingDTO>>;

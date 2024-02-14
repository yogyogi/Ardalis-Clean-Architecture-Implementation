using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Student.List;
public record ListStudentQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<StudentDTO>>>;

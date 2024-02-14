using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Student.Get;
public record GetStudentQuery(int StudentId) : IQuery<Result<StudentDTO>>;

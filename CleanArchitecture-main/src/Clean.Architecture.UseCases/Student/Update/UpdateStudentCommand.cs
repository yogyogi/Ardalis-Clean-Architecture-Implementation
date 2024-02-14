using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Student.Update;
public record UpdateStudentCommand(int StudentId, string NewName, string Standard, int Rank) : ICommand<Result<StudentDTO>>;

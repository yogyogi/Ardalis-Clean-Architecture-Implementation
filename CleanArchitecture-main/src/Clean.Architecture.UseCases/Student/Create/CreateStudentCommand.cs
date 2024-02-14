using Ardalis.Result;

namespace Clean.Architecture.UseCases.Student.Create;
public record CreateStudentCommand(string Name, string Standard, int Rank) : Ardalis.SharedKernel.ICommand<Result<int>>;

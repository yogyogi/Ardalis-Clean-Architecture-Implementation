using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Student.Delete;
public record DeleteStudentCommand(int StudentId) : ICommand<Result>;

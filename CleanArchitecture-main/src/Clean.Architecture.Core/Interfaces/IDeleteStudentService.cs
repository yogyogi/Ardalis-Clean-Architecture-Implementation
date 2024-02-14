using Ardalis.Result;

namespace Clean.Architecture.Core.Interfaces;

public interface IDeleteStudentService
{
  public Task<Result> DeleteStudent(int studentId);
}

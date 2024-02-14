using Ardalis.SharedKernel;

namespace Clean.Architecture.Core.StudentAggregate.Events;
internal sealed class StudentDeletedEvent(int studentId) : DomainEventBase
{
  public int StudentId { get; init; } = studentId;
}

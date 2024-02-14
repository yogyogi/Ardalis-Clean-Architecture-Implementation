using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace Clean.Architecture.Core.StudentAggregate;
public class Student(string name, string standard, int rank) : EntityBase, IAggregateRoot
{
  public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));
  public string Standard { get; private set; } = Guard.Against.NullOrEmpty(standard, nameof(standard));
  public int Rank { get; set; } = Guard.Against.Zero(rank, nameof(rank));

  public void UpdateStudent(string newName, string standard, int rank)
  {
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
    Standard = Guard.Against.NullOrEmpty(standard, nameof(standard));
    Rank = Guard.Against.Zero(rank, nameof(rank));
  }
}

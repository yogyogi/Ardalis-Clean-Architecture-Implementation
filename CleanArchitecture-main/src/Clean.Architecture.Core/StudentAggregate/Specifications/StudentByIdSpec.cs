using Ardalis.Specification;

namespace Clean.Architecture.Core.StudentAggregate.Specifications;
public class StudentByIdSpec : Specification<Student>
{
  public StudentByIdSpec(int studentId)
  {
    Query
        .Where(a => a.Id == studentId);
  }
}

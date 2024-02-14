using Ardalis.Specification;

namespace Clean.Architecture.Core.StudentAggregate.Specifications;
public class StudentByPagingSpec : Specification<Student>
{
  public StudentByPagingSpec(int skip, int take)
  {
    Query.Skip(skip).Take(take);
  }
}

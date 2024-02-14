using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Endpoints.StudentEndpoints;
/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class StudentListValidator : Validator<StudentListRequest>
{
  public StudentListValidator()
  {
    RuleFor(x => x.pageNo)
      .GreaterThan(0);

    RuleFor(x => x.recordPerPage)
      .GreaterThan(0);
  }
}

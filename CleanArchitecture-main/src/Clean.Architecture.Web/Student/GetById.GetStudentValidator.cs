using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Endpoints.StudentEndpoints;
/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class GetStudentValidator : Validator<GetStudentByIdRequest>
{
  public GetStudentValidator()
  {
    RuleFor(x => x.studentId)
      .GreaterThan(0);
  }
}

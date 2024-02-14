using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Endpoints.StudentEndpoints;
/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class DeleteStudentValidator : Validator<DeleteStudentRequest>
{
  public DeleteStudentValidator()
  {
    RuleFor(x => x.StudentId)
      .GreaterThan(0);
  }
}

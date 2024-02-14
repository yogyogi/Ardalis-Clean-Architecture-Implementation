using Clean.Architecture.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Endpoints.StudentEndpoints;

public class UpdateStudentValidator : Validator<UpdateStudentRequest>
{
  public UpdateStudentValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
    RuleFor(x => x.StudentId)
      .Must((args, studentId) => args.Id == studentId)
      .WithMessage("Route and body Ids must match; cannot update Id of an existing resource.");
  }
}

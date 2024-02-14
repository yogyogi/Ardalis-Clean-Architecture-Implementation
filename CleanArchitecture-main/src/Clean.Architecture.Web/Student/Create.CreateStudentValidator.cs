using Clean.Architecture.Infrastructure.Data.Config;
using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Endpoints.StudentEndpoints;

public class CreatStudentValidator : Validator<CreateStudentRequest>
{
  public CreatStudentValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("Name is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

    RuleFor(x => x.Standard)
     .NotEmpty()
     .WithMessage("Standard is required.")
     .MinimumLength(2)
     .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);

    RuleFor(x => x.Rank)
     .NotEmpty()
     .WithMessage("Rank is required.")
     .InclusiveBetween(1, 3)
     .WithMessage("Rank 1-3 allowed");
  }
}

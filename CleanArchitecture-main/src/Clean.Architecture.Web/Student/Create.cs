using Clean.Architecture.UseCases.Student.Create;
using FastEndpoints;
using MediatR;

namespace Clean.Architecture.Web.Endpoints.StudentEndpoints;

public class Create(IMediator _mediator)
  : Endpoint<CreateStudentRequest, CreateStudentResponse>
{
  public override void Configure()
  {
    Post(CreateStudentRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new CreateStudentRequest { Name = "Student Name" };
    });
  }

  public override async Task HandleAsync(
    CreateStudentRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateStudentCommand(request.Name!, request.Standard!, request.Rank));

    if (result.IsSuccess)
    {
      Response = new CreateStudentResponse(result.Value, request.Name!, request.Standard!, request.Rank!);
      return;
    }
  }
}

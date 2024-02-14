using Ardalis.Result;
using FastEndpoints;
using MediatR;
using Clean.Architecture.UseCases.Student.Delete;
using Clean.Architecture.Web.Endpoints.StudentEndpoints;

namespace Clean.Architecture.Web.StudentEndpoints;

public class Delete(IMediator _mediator)
  : Endpoint<DeleteStudentRequest>
{
  public override void Configure()
  {
    Delete(DeleteStudentRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    DeleteStudentRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeleteStudentCommand(request.StudentId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    };
    // TODO: Handle other issues as needed
  }
}

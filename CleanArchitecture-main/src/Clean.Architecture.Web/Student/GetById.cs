using Ardalis.Result;
using FastEndpoints;
using MediatR;
using Clean.Architecture.UseCases.Student.Get;
using Clean.Architecture.Web.Endpoints.StudentEndpoints;

namespace Clean.Architecture.Web.StudentEndpoints;
public class GetById(IMediator _mediator)
  : Endpoint<GetStudentByIdRequest, StudentRecord>
{
  public override void Configure()
  {
    Get(GetStudentByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetStudentByIdRequest request,
    CancellationToken cancellationToken)
  {
    var command = new GetStudentQuery(request.studentId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new StudentRecord(result.Value.Id, result.Value.Name, result.Value.Standard, result.Value.Rank);
    }
  }
}

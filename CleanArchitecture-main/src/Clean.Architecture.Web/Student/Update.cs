using Ardalis.Result;
using Clean.Architecture.UseCases.Student.Get;
using Clean.Architecture.UseCases.Student.Update;
using Clean.Architecture.Web.Endpoints.StudentEndpoints;
using FastEndpoints;
using MediatR;

namespace Clean.Architecture.Web.StudentEndpoints;

public class Update(IMediator _mediator)
  : Endpoint<UpdateStudentRequest, UpdateStudentResponse>
{
  public override void Configure()
  {
    Put(UpdateStudentRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdateStudentRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdateStudentCommand(request.Id, request.Name!, request.Standard!, request.Rank));

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    var query = new GetStudentQuery(request.StudentId);

    var queryResult = await _mediator.Send(query);

    if (queryResult.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (queryResult.IsSuccess)
    {
      var dto = queryResult.Value;
      Response = new UpdateStudentResponse(new StudentRecord(dto.Id, dto.Name, dto.Standard, dto.Rank));
      return;
    }
  }
}

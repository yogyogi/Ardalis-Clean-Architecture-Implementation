using Clean.Architecture.UseCases.Student.List;
using FastEndpoints;
using MediatR;

namespace Clean.Architecture.Web.StudentEndpoints;

public class List(IMediator _mediator) : EndpointWithoutRequest<StudentListResponse>
{
  public override void Configure()
  {
    Get("/Student");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListStudentQuery(null, null));

    if (result.IsSuccess)
    {
      Response = new StudentListResponse
      {
        Student = result.Value.Select(c => new StudentRecord(c.Id, c.Name, c.Standard, c.Rank)).ToList()
      };
    }
  }
}

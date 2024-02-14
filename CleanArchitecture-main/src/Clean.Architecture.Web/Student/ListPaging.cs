using Ardalis.Result;
using FastEndpoints;
using MediatR;
using Clean.Architecture.UseCases.Student.ListPaging;
using Clean.Architecture.Web.Endpoints.StudentEndpoints;
using Clean.Architecture.Web.StudentEndpoints;

namespace Project1.Web.StudentEndpoints;
public class ListPaging(IMediator _mediator)
  : Endpoint<StudentListRequest, StudentPagingRecord>
{
  public override void Configure()
  {
    Get(StudentListRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(StudentListRequest request,
    CancellationToken cancellationToken)
  {
    var command = new ListPagingStudentQuery(request.pageNo, request.recordPerPage);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new StudentPagingRecord(result.Value.s, new PagedInfo(result.Value.CurrentPage, result.Value.ItemsPerPage, result.Value.TotalPages, result.Value.TotalItems));
    }
  }
}

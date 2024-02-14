namespace Clean.Architecture.Web.Endpoints.StudentEndpoints;

public class StudentListRequest
{
  public const string Route = "/Student/Paging/{PageNo:int}";
  public static string BuildRoute(int pageNo) => Route.Replace("{PageNo:int}", pageNo.ToString());

  public int pageNo { get; set; }

  public int recordPerPage = 1;
}

namespace Clean.Architecture.Web.Endpoints.StudentEndpoints;

public record DeleteStudentRequest
{
  public const string Route = "/Student/{StudentId:int}";
  public static string BuildRoute(int studentId) => Route.Replace("{StudentId:int}", studentId.ToString());

  public int StudentId { get; set; }
}

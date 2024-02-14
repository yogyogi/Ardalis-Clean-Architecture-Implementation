using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.Web.Endpoints.StudentEndpoints;

public class UpdateStudentRequest
{
  public const string Route = "/Student/{StudentId:int}";
  public static string BuildRoute(int StudentId) => Route.Replace("{StudentId:int}", StudentId.ToString());

  public int StudentId { get; set; }

  public int Id { get; set; }

  [Required]
  public string? Name { get; set; }

  [Required]
  public string? Standard { get; set; }

  [Range(1, 3)]
  public int Rank { get; set; }
}

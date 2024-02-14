using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.Web.Endpoints.StudentEndpoints;

public class CreateStudentRequest
{
  public const string Route = "/Student";

  [Required]
  public string? Name { get; set; }

  [Required]
  public string? Standard { get; set; }

  [Range(1, 3)]
  public int Rank { get; set; }
}

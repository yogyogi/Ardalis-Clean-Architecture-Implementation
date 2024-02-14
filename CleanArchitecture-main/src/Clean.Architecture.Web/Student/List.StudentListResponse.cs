namespace Clean.Architecture.Web.StudentEndpoints;

public class StudentListResponse
{
  public List<StudentRecord> Student { get; set; } = new();
}

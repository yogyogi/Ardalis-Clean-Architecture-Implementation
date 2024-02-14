using Clean.Architecture.Web.StudentEndpoints;

namespace Clean.Architecture.Web.Endpoints.StudentEndpoints;

public class UpdateStudentResponse
{
  public UpdateStudentResponse(StudentRecord student)
  {
    Student = student;
  }
  public StudentRecord Student { get; set; }
}

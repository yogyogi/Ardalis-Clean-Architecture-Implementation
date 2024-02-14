namespace Clean.Architecture.Web.Endpoints.StudentEndpoints;

public class CreateStudentResponse
{
  public CreateStudentResponse(int id, string name, string standard, int rank)
  {
    Id = id;
    Name = name;
    Standard = standard;
    Rank = rank;
  }
  public int Id { get; set; }
  public string Name { get; set; }
  public string Standard { get; set; }
  public int Rank { get; set; }
}


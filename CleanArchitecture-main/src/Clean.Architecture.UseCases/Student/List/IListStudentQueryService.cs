namespace Clean.Architecture.UseCases.Student.List;
public interface IListStudentQueryService
{
  Task<IEnumerable<StudentDTO>> ListAsync();
}

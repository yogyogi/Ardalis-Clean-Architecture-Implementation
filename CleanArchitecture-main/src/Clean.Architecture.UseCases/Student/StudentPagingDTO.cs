namespace Clean.Architecture.UseCases.Student;
public record StudentPagingDTO(List<StudentDTO> s, int TotalItems, int ItemsPerPage, int CurrentPage, int TotalPages);


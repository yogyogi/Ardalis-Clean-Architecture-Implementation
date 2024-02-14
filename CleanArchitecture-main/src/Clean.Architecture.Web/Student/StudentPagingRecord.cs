using Ardalis.Result;
using Clean.Architecture.UseCases.Student;

namespace Clean.Architecture.Web.StudentEndpoints;

public record StudentPagingRecord(List<StudentDTO> StudentList, PagedInfo PI);

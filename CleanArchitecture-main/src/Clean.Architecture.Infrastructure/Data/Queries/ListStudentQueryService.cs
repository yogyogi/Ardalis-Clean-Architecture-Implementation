using Clean.Architecture.UseCases.Student;
using Clean.Architecture.UseCases.Student.List;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure.Data.Queries;
public class ListStudentQueryService(AppDbContext _db) : IListStudentQueryService
{
  public async Task<IEnumerable<StudentDTO>> ListAsync()
  {
    var result = await _db.Database.SqlQuery<StudentDTO>($"SELECT Id, Name, Standard, Rank FROM Student").ToListAsync();

    return result;
  }
}


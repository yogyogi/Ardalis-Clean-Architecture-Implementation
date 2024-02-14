using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure.Data;
public class AppIdentityDbContext : IdentityDbContext
{
  public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
  {
  }
}

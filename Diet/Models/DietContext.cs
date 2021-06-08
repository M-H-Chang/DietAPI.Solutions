using Microsoft.EntityFrameworkCore;
namespace Diet.Models
{
  public class DietContext : DbContext
  {
    public DietContext(DbContextOptions<DietContext> options)
    : base(options)
    {
    }
    public DbSet<Diet> Diets { get; set; }
  }
}
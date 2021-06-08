using Microsoft.EntityFrameworkCore;
namespace DietList.Models
{
  public class DietListContext : DbContext
  {
    public DietListContext(DbContextOptions<DietListContext> options)
    : base(options)
    {

    }
    public DbSet<Diet> Diets { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Diet>()
      .hasData(
        new Diet { DietId = 1, Name = "Regular" },
        new Diet { DietId = 2, Name = "Paleo" },
        new Diet { DietId = 3, Name = "Vegan" },
        new Diet { DietId = 4, Name = "Low-Carb" },
        new Diet { DietId = 5, Name = "Dukan" },
        new Diet { DietId = 6, Name = "Atkins" },
        new Diet { DietId = 7, Name = "Intermittent-Fasting" }
      );
    }
  }
}
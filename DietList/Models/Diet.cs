using System.ComponentModel.DataAnnotations;
namespace Diet.Models
{
  public class Diet
  {
    public int DietId { get; set; }
    [Required]
    [StringLength(20)]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public string Restriction { get; set; }
  }
}
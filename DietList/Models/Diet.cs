using System.ComponentModel.DataAnnotations;
namespace DietList.Models
{
  public class Diet
  {
    public int DietId { get; set; }
    [Required]
    [StringLength(20)]
    public string Name { get; set; }
    public string Restriction { get; set; }
  }
}
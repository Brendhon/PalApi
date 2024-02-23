using System.ComponentModel.DataAnnotations;

namespace PalModel;

public partial class Pal
{
  [Key]
  [Required(ErrorMessage = "Id is required")]
  public int Id { get; set; }

  [Required(ErrorMessage = "Name is required")]
  public required string Name { get; set; }

  [Required(ErrorMessage = "Type is required")]
  public required string Type { get; set; }
}

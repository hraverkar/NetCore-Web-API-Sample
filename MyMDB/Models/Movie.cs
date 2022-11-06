using MyMDB.Data;
using System.ComponentModel.DataAnnotations;

namespace MyMDB.Models
{
  public class Movie : IEntity
  {
    public Guid Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Title { get; set; }

    [Required]
    [StringLength(30)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
    public string Genre { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
  }
}

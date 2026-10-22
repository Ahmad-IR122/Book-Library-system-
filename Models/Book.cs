using System;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
  public class Book
  {
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Title { get; set; }

    [Required]
    [StringLength(255)]
    public string Author { get; set; }

    [Required]
    [StringLength(10)]
    public string ISBN { get; set; }


    [StringLength(1000)]
    public string Description { get; set; }

    [Range(0, 999999.99)]
    public decimal Price { get; set; }

    [Range(0, 10000)]
    public int Quantity { get; set; }

    [StringLength(100)]
    public string Genre { get; set; }

    public DateTime PublishedDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
  }
}
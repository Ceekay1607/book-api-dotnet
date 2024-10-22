using System.ComponentModel.DataAnnotations;

namespace book_api;

public class Book
{
    public int Id { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required.")]
    public string? Title { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Author is required.")]
    public string? Author { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
    public double Price { get; set; }
}

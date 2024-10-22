using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace book_api;

public class CreateBookRequest
{
    [JsonProperty("title")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required.")]
    public string? Title { get; set; }

    [JsonProperty("author")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Author is required.")]
    public string? Author { get; set; }

    [JsonProperty("price")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
    public double Price { get; set; }
}

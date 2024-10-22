using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace book_api;

public class RegisterRequest
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
    public string? Username { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
    public string? Password { get; set; }
    public bool Admin { get; set; }
}

namespace book_api;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool Admin { get; set; } = false;
}

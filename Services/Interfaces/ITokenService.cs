namespace book_api;

public interface ITokenService
{
    string GenerateToken(User user);
}

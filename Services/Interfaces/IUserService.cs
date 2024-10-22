namespace book_api;

public interface IUserService
{
    Task<User> Register(RegisterRequest registerRequest);
}

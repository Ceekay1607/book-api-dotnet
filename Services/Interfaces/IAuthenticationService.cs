namespace book_api;

public interface IAuthenticationService
{
    Task<string> Login (LoginRequest? loginRequest);
}

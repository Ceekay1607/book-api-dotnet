
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace book_api;

public class AuthenticationService : IAuthenticationService
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly PasswordHasher<User> _passwordHasher;
    private readonly ITokenService _tokenService;

    public AuthenticationService(ApplicationDbContext applicationDbContext, ITokenService tokenService){
        _applicationDbContext = applicationDbContext;
        _passwordHasher = new PasswordHasher<User>();
        _tokenService = tokenService;
    }

    public async Task<string> Login(LoginRequest loginRequest)
    {
        User? user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Username == loginRequest.Username);
        if(user == null) {
            throw new UnauthorizedAccessException("Invalid username or password.");
        }

        var passwordVerification = _passwordHasher.VerifyHashedPassword(user, user.Password, loginRequest.Password);

        if(passwordVerification == PasswordVerificationResult.Failed) {
            throw new UnauthorizedAccessException("Invalid username or password.");
        }

        return _tokenService.GenerateToken(user);
    }
}

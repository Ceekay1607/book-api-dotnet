
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace book_api;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly PasswordHasher<User> _passwordHasher;

    public UserService(ApplicationDbContext applicationDbContext){
        _applicationDbContext = applicationDbContext;
        _passwordHasher = new PasswordHasher<User>();
    }

    public async Task<User> Register(RegisterRequest registerRequest)
    {
        var user = new User { Username = registerRequest.Username, Admin = registerRequest.Admin };
        user.Password = _passwordHasher.HashPassword(user, registerRequest.Password);

        await _applicationDbContext.AddAsync(user);
        await _applicationDbContext.SaveChangesAsync();

        return user;
    }
}

using Microsoft.AspNetCore.Mvc;

namespace book_api;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService) {
         _authenticationService = authenticationService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest? loginRequest) {
        try {
            var token = await _authenticationService.Login(loginRequest);
            if (string.IsNullOrEmpty(token)) {
                return BadRequest();
            }
            var response = new LoginResponse{Username = loginRequest.Username, Token = token};
            return Ok(response);
        } catch (UnauthorizedAccessException e) {
            return Unauthorized(e.Message);
        }
    }
}

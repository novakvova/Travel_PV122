using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpGet("google")]
    public IActionResult GoogleLogin()
    {
        var properties = new AuthenticationProperties
        {
            RedirectUri = Url.Action(nameof(GoogleResponse), "Auth")
        };

        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet("google/response")]
    public async Task<IActionResult> GoogleResponse()
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

    

        return Ok();
    }

    // Другие методы вашего контроллера...
}

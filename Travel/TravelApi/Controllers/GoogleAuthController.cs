using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.Auth;

public class GoogleLoginViewModel
{
    public string Token { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class GoogleAuthController : ControllerBase
{
   

    [HttpPost("googleauth")]
    public async Task<IActionResult> GoogleResponse([FromForm] GoogleLoginViewModel model)
    {
        string clientID = "763864234936-s953ounakf8bemdaqva8hlao2dai2dj5.apps.googleusercontent.com";
        var setting = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new List<string>() { clientID }
        };
        var payload = await GoogleJsonWebSignature.ValidateAsync(model.Token, setting);

        if(payload == null)
        {
            return BadRequest();
        }

        return Ok(payload.Email);
    }

    
}

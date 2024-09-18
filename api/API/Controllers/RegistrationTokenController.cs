using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("registration-token")]
public class RegistrationTokenController(IRegistrationTokenService registrationTokenService) : ControllerBase
{
    [HttpGet("by-token")]
    public async Task<ActionResult<RegistrationToken>> GetByToken([FromQuery] Guid token)
    {
        var response = await registrationTokenService.GetByToken(token);

        return response == new RegistrationToken()
            ? BadRequest()
            : Ok(response);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateByEmail([FromQuery] string email)
    {
        await registrationTokenService.CreateByEmail(email, HttpContext.User.Claims);
        return Ok();
    }
}
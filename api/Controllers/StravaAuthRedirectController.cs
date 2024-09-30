using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StravaAuthRedirectController : ControllerBase
{

    private readonly Config _config;
    public StravaAuthRedirectController(Config config)
    {
        _config = config;
    }

    [HttpGet]
    [ActionName("strava-auth-redirect")]
    public RedirectResult? GetStravaAuth()
    {


        if (_config.STRAVAAUTHURL == null)
            return null;

        return Redirect(_config.STRAVAAUTHURL);
    }
}
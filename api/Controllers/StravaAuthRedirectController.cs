using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StravaAuthRedirectController : ControllerBase
{

    private HttpClient _client;
    private Exception HttpResponseException(Exception exception)
    {
        throw new NotImplementedException();
    }


    public StravaAuthRedirectController(HttpClient client)
    {
        _client = client;
    }

    [HttpGet]
    [ActionName("strava-auth-redirect")]
    public RedirectResult GetStravaAuth()
    {


        return Redirect("http://www.strava.com/oauth/authorize?client_id=136237&response_type=code&redirect_uri=http://localhost:5173/api/stravaauth&approval_prompt=force&scope=read");


    }
}
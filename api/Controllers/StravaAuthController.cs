using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StravaAuthController : ControllerBase
{

    private HttpClient _client;
    private StravaToken _stravaToken;
    private Exception HttpResponseException(Exception exception)
    {
        throw new NotImplementedException();
    }


    public StravaAuthController(HttpClient client, StravaToken stravaToken)
    {
        _client = client;
        _stravaToken = stravaToken;
    }

    [HttpGet]
    [ActionName("strava-auth")]
    public async Task<string> GetStravaAuthAsync([FromQuery(Name = "code")] string code)
    {

        try
        {
            Console.WriteLine("Passing Auth URL Through:" + code);
            var auth = await _stravaToken.GetStravaRefreshToken(code);

            if (auth == null)
                return "Authentication Failed";

            return "Successfully authenticated";
        }
        catch (Exception exception)
        {
            Console.WriteLine("CAUGHT EXCEPTION:");
            Console.WriteLine(exception);
            throw HttpResponseException(exception);
        }
    }
}
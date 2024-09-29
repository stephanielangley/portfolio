using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StravaController : ControllerBase
{

    private HttpClient _client;

    private StravaToken _stravaToken;
    private Exception HttpResponseException(Exception exception)
    {
        throw new NotImplementedException();
    }


    public StravaController(HttpClient client, StravaToken stravaToken)
    {
        _client = client;
        _stravaToken = stravaToken;
    }

    [HttpGet]
    [ActionName("activity-stats")]
    public async Task<ActivityStats?> GetActivityStatsAsync()
    {

        var accessToken = await _stravaToken.GetAccessToken();

        Console.WriteLine("Token: " + accessToken);

        if (accessToken == "Authentication Required")
            return null;

        _client.DefaultRequestHeaders.Authorization =
new AuthenticationHeaderValue("Bearer", accessToken);

        try
        {
            HttpResponseMessage response = await _client.GetAsync("https://www.strava.com/api/v3/athletes/16045483/stats");

            response.EnsureSuccessStatusCode();
            Console.WriteLine("SUCCESS:");
            Console.WriteLine(response);
            return await response.Content.ReadFromJsonAsync<ActivityStats>();
        }
        catch (Exception exception)
        {
            Console.WriteLine("CAUGHT EXCEPTION:");
            Console.WriteLine(exception);
            throw HttpResponseException(exception);
        }
    }
}
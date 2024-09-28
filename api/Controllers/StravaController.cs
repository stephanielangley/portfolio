using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StravaController : ControllerBase
{

    private readonly ILogger<StravaController> _logger;
    private HttpClient _client;
    private readonly IConfiguration _config;

    public StravaController(ILogger<StravaController> logger, HttpClient client, IConfiguration config)
    {
        _logger = logger;
        _client = client;
        _config = config;
    }

    [HttpGet("activity-stats")]
    public async Task<ActivityStats?> GetActivityStatsAsync()
    {
        var stravaApiKey = _config["Strava:ServiceApiKey"];

        // var environment = Environment.GetEnvironmentVariable("strava");
        _client.DefaultRequestHeaders.Authorization =
new AuthenticationHeaderValue("Bearer", stravaApiKey);

        try
        {
            HttpResponseMessage response = await _client.GetAsync("https://www.strava.com/api/v3/athletes/16045483/stats");

            response.EnsureSuccessStatusCode();
            System.Diagnostics.Debug.WriteLine("SUCCESS:");
            System.Diagnostics.Debug.WriteLine(response);
            return await response.Content.ReadFromJsonAsync<ActivityStats>();
        }
        catch (Exception exception)
        {
            System.Diagnostics.Debug.WriteLine("CAUGHT EXCEPTION:");
            System.Diagnostics.Debug.WriteLine(exception);
            throw HttpResponseException(exception);
        }
    }

    private Exception HttpResponseException(Exception exception)
    {
        throw new NotImplementedException();
    }
}
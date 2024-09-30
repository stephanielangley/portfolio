namespace api;

public class ActivityStats
{
    public double biggest_ride_distance { get; set; }
    public double biggest_climb_elevation_gain { get; set; }
    public required ActivityTotal recent_ride_totals { get; set; }
    public required ActivityTotal recent_run_totals { get; set; }
    public required ActivityTotal recent_swim_totals { get; set; }
    public required ActivityTotal ytd_ride_totals { get; set; }
    public required ActivityTotal ytd_run_totals { get; set; }
    public required ActivityTotal ytd_swim_totals { get; set; }
    public required ActivityTotal all_ride_totals { get; set; }
    public required ActivityTotal all_run_totals { get; set; }
    public required ActivityTotal all_swim_totals { get; set; }

}

public class ActivityTotal
{
    public int count { get; set; }
    public double biggest_climb_elevation_gain { get; set; }
    public float distance { get; set; }
    public int moving_time { get; set; }
    public int elapsed_time { get; set; }
    public float elevation_gain { get; set; }
    public int achievement_count { get; set; }

}

public class AuthCredentials
{
    public string token_type { get; set; } = "";
    public string access_token { get; set; } = "";
    public int expires_at { get; set; } = 0;
    public int expires_in { get; set; } = 0;
    public string refresh_token { get; set; } = "";

}

public class StravaToken(HttpClient client, Config config)
{
    private HttpClient _client = client;
    private readonly Config _config = config;

    private Exception HttpResponseException(Exception exception)
    {
        throw new NotImplementedException();
    }

    public required string access_token { get; set; }
    public int expires_at { get; set; }
    public int expires_in { get; set; }
    private string? refresh_token { get; set; }

    public async Task<string?> GetAccessToken()
    {
        Int32 unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;



        if (refresh_token == null)
        {
            Console.WriteLine("Getting Strava Refresh Token");
            return "Authentication Required";
        }

        Console.WriteLine("Time: " + unixTimestamp + " Expires: " + expires_at);
        if (unixTimestamp < expires_at)
        {
            Console.WriteLine("Returning cached token");
            return access_token;
        }


        Console.WriteLine("Getting Strava Auth Token ");
        var stravaAuth = await GetStravaAuthenticationToken();

        if (stravaAuth == null)
            return null;

        access_token = stravaAuth.access_token;
        expires_at = stravaAuth.expires_at;
        expires_in = stravaAuth.expires_in;
        refresh_token = stravaAuth.refresh_token;

        Console.WriteLine("expires " + expires_at);

        Console.WriteLine("strava auth: " + stravaAuth);

        return access_token;
    }


    public async Task<AuthCredentials?> GetStravaAuthenticationToken()
    {
        Console.WriteLine("refresh token: " + refresh_token);

        if (_config.STRAVACLIENTID == null || _config.STRAVASECRET == null || refresh_token == null)
        { return null; }

        var formContent = new FormUrlEncodedContent(new[]
{
    new KeyValuePair<string, string>("client_id", _config.STRAVACLIENTID),
    new KeyValuePair<string, string>("client_secret", _config.STRAVASECRET),
    new KeyValuePair<string, string>("grant_type", "refresh_token"),
    new KeyValuePair<string, string>("refresh_token", refresh_token)
});

        try
        {
            HttpResponseMessage response = await _client.PostAsync("https://www.strava.com/api/v3/oauth/token", formContent);
            Console.WriteLine("response :" + response);

            return await response.Content.ReadFromJsonAsync<AuthCredentials>();
        }
        catch (Exception exception)
        {
            Console.WriteLine("CAUGHT EXCEPTION:");
            Console.WriteLine(exception);
            throw HttpResponseException(exception);
        }
    }

    public async Task<AuthCredentials?> GetStravaRefreshToken(string code)
    {
        if (_config.STRAVACLIENTID == null || _config.STRAVASECRET == null)
        { return null; }

        var formContent = new FormUrlEncodedContent(new[]
       {
    new KeyValuePair<string, string>("client_id",  _config.STRAVACLIENTID),
    new KeyValuePair<string, string>("client_secret", _config.STRAVASECRET),
        new KeyValuePair<string, string>("code", code),
        new KeyValuePair<string, string>("grant_type", "authorization_code")
    });

        Console.WriteLine("Authorization values: " + code);
        try
        {
            HttpResponseMessage response = await _client.PostAsync("https://www.strava.com/api/v3/oauth/token", formContent);

            var stravaAuth = await response.Content.ReadFromJsonAsync<AuthCredentials>();
            if (stravaAuth == null)
                return null;

            access_token = stravaAuth.access_token;
            expires_at = stravaAuth.expires_at;
            expires_in = stravaAuth.expires_in;
            refresh_token = stravaAuth.refresh_token;
            Console.WriteLine("strava auth object" + stravaAuth);
            return stravaAuth;
        }
        catch (Exception exception)
        {
            Console.WriteLine("CAUGHT EXCEPTION:");
            Console.WriteLine(exception);
            throw HttpResponseException(exception);
        }

    }

}


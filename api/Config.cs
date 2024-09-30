namespace api;
#pragma warning disable CS8601 // Possible null reference assignment. Null handlers in code to handle this.
public class Config
{
    public string STRAVACLIENTID = Environment.GetEnvironmentVariable("STRAVACLIENTID");
    public string STRAVAATHLETEID = Environment.GetEnvironmentVariable("STRAVAATHLETEID");
    public string STRAVASECRET = Environment.GetEnvironmentVariable("STRAVASECRET");
    public string STRAVAAUTHURL = Environment.GetEnvironmentVariable("STRAVAAUTHURL");
}
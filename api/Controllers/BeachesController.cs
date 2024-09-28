using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BeachesController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<BeachesController> _logger;

    public BeachesController(ILogger<BeachesController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Beaches")]
    public IEnumerable<Beaches> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Beaches
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BeachesController : ControllerBase
{

    private readonly ILogger<BeachesController> _logger;
    private readonly PortfolioDbContext _context;

    public BeachesController(ILogger<BeachesController> logger, PortfolioDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Beach>>> getBeaches()
    {

        if (_context.Beaches == null) { return NotFound(); }

        return await _context.Beaches.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Beach>> getBeach(int id)
    {

        if (_context.Beaches == null) { return NotFound(); }

        var beach = await _context.Beaches.FindAsync(id);
        if (beach == null) { return NotFound(); }
        return beach;
    }

    [HttpPost]
    public async Task<ActionResult<Beach>> postBeaches([FromBody] Beach beachvalue)
    {
        Console.WriteLine("OBJECT: " + beachvalue);
        try
        {


            _context.Beaches.Add(beachvalue);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created,
                 beachvalue);

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new beach record");
        }

    }

}

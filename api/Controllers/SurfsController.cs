using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SurfsController : ControllerBase
{

    private readonly ILogger<SurfsController> _logger;
    private readonly PortfolioDbContext _context;

    public SurfsController(ILogger<SurfsController> logger, PortfolioDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SurfsReturned>>> getSurfs()
    {
        try
        {
            if (_context.Surfs == null) { return NotFound(); }
            if (_context.Beaches == null) { return NotFound(); }

            var returnSurfs = await _context.Surfs
             .Join(
                  _context.Beaches,
                  surf_table => surf_table.surf_beach_id,
                  beach_table => beach_table.beach_id,
                  (surf_table, beach_table) => new
                  {
                      surf_table.surf_id,
                      beach_table.beach_id,
                      beach_table.name,
                      beach_table.description,
                      beach_table.latitude,
                      beach_table.longitude,
                      surf_table.date
                  })
                  .Select(x => new SurfsReturned()
                  {
                      surf_id = x.surf_id,
                      name = x.name,
                      description = x.description,
                      latitude = x.latitude,
                      longitude = x.longitude,
                      date = x.date
                  }).OrderByDescending(surf => surf.date)
             .ToListAsync();

            if (returnSurfs == null) { return NotFound(); }

            return returnSurfs;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error getting surf records");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Surf>> getSurf(int id)
    {

        if (_context.Surfs == null) { return NotFound(); }

        var surf = await _context.Surfs.FindAsync(id);
        if (surf == null) { return NotFound(); }
        return surf;
    }

    [HttpPost]
    public async Task<ActionResult<Surf>> postSurfs([FromBody] Surf surfvalue)
    {
        Console.WriteLine("OBJECT: " + surfvalue);
        try
        {
            _context.Surfs.Add(surfvalue);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created,
                 surfvalue);

        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new surf record");
        }

    }

}

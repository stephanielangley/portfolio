using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace api;

public class PortfolioDbContext : DbContext
{
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options) { }

    public DbSet<Beach> Beaches { get; set; }
    public DbSet<Surf> Surfs { get; set; }
}

public class Beach
{
    [Key]
    public int? beach_id { get; set; }
    public required string name { get; set; }

    public required string description { get; set; }

    public required double latitude { get; set; }

    public required double longitude { get; set; }
}

public class Surf
{
    [Key]
    public int? surf_id { get; set; }

    [ForeignKey("Beach")]
    public required int surf_beach_id { get; set; }

    public required string date { get; set; }
}

public class SurfsReturned
{
    public int? surf_id { get; set; }

    public int? beach_id { get; set; }
    public required string name { get; set; }
    public required string description { get; set; }
    public required double latitude { get; set; }
    public required double longitude { get; set; }

    public required string date { get; set; }
}

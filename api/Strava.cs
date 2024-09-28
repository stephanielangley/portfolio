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
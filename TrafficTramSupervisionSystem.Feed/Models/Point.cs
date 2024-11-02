namespace TrafficTramSupervisionSystem.Feed.Models;

public record Point
{
    /// <summary>
    /// The factor to convert between TTSS-provided coordinates and longitude/latitudes in range [-180, 180]/[-90, 90].
    /// </summary>
    public const double ConversionFactor = 3_600_000;
    
    /// <summary>
    /// The longitude of the point, between -180 and 180.
    /// </summary>
    public required double Longitude { get; init; }
    
    /// <summary>
    /// The latitude of the point, between -90 and 90.
    /// </summary>
    public required double Latitude { get; init; }
    
    public double TtssLongitude => Longitude * ConversionFactor;
    public double TtssLatitude => Latitude * ConversionFactor;
}

using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using TtssClient.Models;

namespace TtssClient.Dtos.Responses;

public record PathsResponse : IResponse<PathsResponse>
{
    [JsonPropertyName("paths")] public List<Path> Paths { get; init; }
    public static JsonTypeInfo<PathsResponse> TypeInfo { get; } = JsonSerializers.Default.PathsResponse;
}

public record Path
{
    [JsonPropertyName("color")] public string Color { get; init; }

    [JsonPropertyName("wayPoints")] public List<PathPoint> RawWaypoints { get; init; }

    [JsonIgnore] public List<Point> Waypoints => RawWaypoints.Select(PathPointToPointExtension.ToPoint).ToList();
}

public record PathPoint
{
    [JsonPropertyName("lat")] public long Latitude { get; init; }

    [JsonPropertyName("lon")] public long Longitude { get; init; }

    [JsonPropertyName("seq")] public string SequenceNumber { get; init; }
}

file static class PathPointToPointExtension
{
    public static Point ToPoint(this PathPoint pathPoint) => new()
    {
        Latitude = pathPoint.Latitude / Point.ConversionFactor,
        Longitude = pathPoint.Longitude / Point.ConversionFactor
    };
}

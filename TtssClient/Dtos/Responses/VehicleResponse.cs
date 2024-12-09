using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using TtssClient.Models;

namespace TtssClient.Dtos.Responses;

public record VehicleResponse : IResponse<VehicleResponse>
{
    [JsonPropertyName("lastUpdate")] public long LastUpdate { get; init; }
    [JsonPropertyName("vehicles")] public List<Vehicle> Vehicles { get; init; }
    public static JsonTypeInfo<VehicleResponse> TypeInfo { get; } = JsonSerializers.Default.VehicleResponse;
}

public record Vehicle
{
    /// <summary>
    /// All other properties apart from <see cref="VehicleId"/> are unset if this is <c>true</c>.
    /// </summary>
    [JsonPropertyName("isDeleted")]
    public bool IsDeleted { get; init; } = false;

    [JsonPropertyName("id")] public string VehicleId { get; init; }
    [JsonPropertyName("color")] public string? Color { get; init; }
    [JsonPropertyName("heading")] public int? Heading { get; init; }
    [JsonPropertyName("latitude")] public long? RawLatitude { get; init; }
    [JsonPropertyName("longitude")] public long? RawLongitude { get; init; }

    public Point? Position => RawLatitude is { } latitude && RawLongitude is { } longitude
        ? new Point
        {
            Latitude = latitude / Point.ConversionFactor,
            Longitude = longitude / Point.ConversionFactor
        }
        : null;

    [JsonPropertyName("name")] public string? Direction { get; init; }
    [JsonPropertyName("tripId")] public string? TripId { get; init; }
    [JsonPropertyName("category")] public string? VehicleType { get; init; }

    /// <summary>
    /// Might not exist, even when the vehicle is not deleted.
    /// </summary>
    [JsonPropertyName("path")]
    public List<VehiclePath>? Path { get; init; }
}

public record VehiclePath
{
    [JsonPropertyName("x1")] public long RawLongitudeStart { get; init; }
    [JsonPropertyName("y1")] public long RawLatitudeStart { get; init; }
    [JsonPropertyName("x2")] public long RawLongitudeEnd { get; init; }
    [JsonPropertyName("y2")] public long RawLatitudeEnd { get; init; }
    [JsonPropertyName("angle")] public int Heading { get; init; }
    [JsonPropertyName("length")] public double Length { get; init; }

    public Point Start => new()
    {
        Longitude = RawLongitudeStart / Point.ConversionFactor,
        Latitude = RawLatitudeStart / Point.ConversionFactor
    };

    public Point End => new()
    {
        Longitude = RawLongitudeEnd / Point.ConversionFactor,
        Latitude = RawLatitudeEnd / Point.ConversionFactor
    };
}

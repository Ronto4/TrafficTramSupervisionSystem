using System.Text.Json.Serialization;

namespace TrafficTramSupervisionSystem.Feed.Dtos;

/// <summary>
/// Information about one stop in the network.
/// </summary>
public record Stop
{
    /// <summary>
    /// Indicates the type of the stop.
    ///
    /// Typical values include "bus" and "tram" as well as "other" which seems to be a
    /// catch-all for tram-bus-mixed stops as well as some other stops (temporary or ferry stops).
    /// </summary>
    [JsonPropertyName("category")]
    public string Category { get; init; }
    
    /// <summary>
    /// The ID of the stop.
    /// Not to be confused with the <see cref="ShortName"/>.
    /// </summary>
    [JsonPropertyName("id")] public string Id { get; init; }
    /// <summary>
    /// The latitude of the stop. Divide by 3_600_000 to get values in range [-180, 180].
    /// </summary>
    [JsonPropertyName("latitude")] public long Latitude { get; init; }
    /// <summary>
    /// The longitude of the stop. Divide by 3_600_000 to get values in range [-90, 90].
    /// </summary>
    [JsonPropertyName("longitude")] public long Longitude { get; init; }
    /// <summary>
    /// The name of the stop.
    /// </summary>
    [JsonPropertyName("name")] public string Name { get; init; }
    /// <summary>
    /// A short version of the stop name, typically in form of a numeric code.
    ///
    /// This code is used to ask for information about this station.
    /// Not to be confused with the <see cref="Id"/>.
    /// </summary>
    [JsonPropertyName("shortName")] public string ShortName { get; init; }
}

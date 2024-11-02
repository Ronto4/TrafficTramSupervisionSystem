using System.Text.Json.Serialization;

namespace TrafficTramSupervisionSystem.Feed.Dtos;

public record StopPoint
{
    /// <summary>
    /// Known to be `bus`, `tram`, or `other`.
    /// Other values have never been seen by the author but cannot be ruled out.
    /// </summary>
    [JsonPropertyName("category")]
    public string Category { get; init; }
    
    [JsonPropertyName("id")]
    public string Id { get; init; }
    
    /// <summary>
    /// A label used to distinguish this stop point from
    /// others of the same stop in customer communication.
    /// </summary>
    [JsonPropertyName("label")]
    public string Label { get; init; }
    
    [JsonPropertyName("latitude")]
    public long Latitude { get; init; }
    
    [JsonPropertyName("longitude")]
    public long Longitude { get; init; }
    
    /// <summary>
    /// The name of the stop point, including its number.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }
    
    /// <summary>
    /// The short name (id) of the associated stop.
    /// </summary>
    [JsonPropertyName("shortName")]
    public string StopId { get; init; }
    
    /// <summary>
    /// The short name of this stop point, i.e. its number.
    /// </summary>
    [JsonPropertyName("stopPoint")]
    public string ShortName { get; init; }
}

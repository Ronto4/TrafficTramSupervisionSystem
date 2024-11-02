using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace TrafficTramSupervisionSystem.Feed.Dtos.Responses;

public record RouteStopsResponse : IResponse<RouteStopsResponse>
{
    [JsonPropertyName("route")] public Route Route { get; init; }
    [JsonPropertyName("stops")] public List<RouteStopsStop> Stops { get; init; }
    public static JsonTypeInfo<RouteStopsResponse> TypeInfo { get; } = JsonSerializers.Default.RouteStopsResponse;
}

public record RouteStopsStop
{
    /// <summary>
    /// The ID of the stop.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; }

    /// <summary>
    /// The name of the stop for customers.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }

    /// <summary>
    /// The short name, i.e. number of the stop.
    /// </summary>
    [JsonPropertyName("number")]
    public string ShortName { get; init; }
}

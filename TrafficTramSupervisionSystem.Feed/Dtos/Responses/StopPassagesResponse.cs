using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace TrafficTramSupervisionSystem.Feed.Dtos.Responses;

/// <summary>
/// The result of asking for <see cref="Passage"/>s at a specific stop or stop point.
/// </summary>
public record StopPassagesResponse : IResponse<StopPassagesResponse>
{
    /// <summary>
    /// Departures that lie in the future.
    /// </summary>
    [JsonPropertyName("actual")]
    public List<Passage> Actual { get; init; }

    /// <summary>
    /// Usage is unclear. It seems to be empty at all times.
    /// </summary>
    [JsonPropertyName("directions")]
    public List<object> Directions { get; init; }

    /// <summary>
    /// The unix time stamp (times 1000) of the first <see cref="Passage"/> in this response.
    /// </summary>
    [JsonPropertyName("firstPassageTime")]
    public long FirstPassageTime { get; init; }

    /// <summary>
    /// A list of <see cref="Alert"/>s currently active at this stop, relevant for all routes.
    /// </summary>
    [JsonPropertyName("generalAlerts")]
    public List<Alert> Alerts { get; init; }

    /// <summary>
    /// The unix time stamp (times 1000) of the last <see cref="Passage"/> in this response.
    /// </summary>
    [JsonPropertyName("lastPassageTime")]
    public long LastPassageTime { get; init; }

    /// <summary>
    /// Departures that lie in the past.
    /// </summary>
    [JsonPropertyName("old")]
    public List<Passage> Old { get; init; }

    /// <summary>
    /// A list of all <see cref="RouteWithType"/>s that are present in <see cref="Actual"/> and <see cref="Old"/>.
    /// </summary>
    [JsonPropertyName("routes")]
    public List<RouteWithType> Routes { get; init; }

    /// <summary>
    /// The name of the stop.
    /// </summary>
    [JsonPropertyName("stopName")]
    public string StopName { get; init; }

    /// <summary>
    /// A short version of the stop or stop point name, typically in form of a numeric code.
    ///
    /// This code is used to ask for information about this station.
    /// </summary>
    [JsonPropertyName("stopShortName")]
    public string StopShortName { get; init; }

    public static JsonTypeInfo<StopPassagesResponse> TypeInfo { get; } = JsonSerializers.Default.StopPassagesResponse;
}

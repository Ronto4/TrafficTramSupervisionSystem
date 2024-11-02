using System.Text.Json.Serialization;

namespace TrafficTramSupervisionSystem.Feed.Dtos;

/// <summary>
/// Information about one line of the network.
/// </summary>
public record Route
{
    /// <summary>
    /// Route-specific <see cref="Alert"/>s.
    /// </summary>
    [JsonPropertyName("alerts")]
    public List<Alert> Alerts { get; init; }

    /// <summary>
    /// The operator of this route.
    /// </summary>
    [JsonPropertyName("authority")]
    public string Authority { get; init; }

    /// <summary>
    /// A list of the endpoints of this route.
    /// </summary>
    [JsonPropertyName("directions")]
    public List<string> Directions { get; init; }

    /// <summary>
    /// The route's ID.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; init; }

    /// <summary>
    /// The name of the route, typically the line number.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; init; }

    /// <summary>
    /// Typically the same as <see cref="Name"/>.
    /// </summary>
    [JsonPropertyName("shortName")]
    public string ShortName { get; init; }
}

/// <summary>
/// Information about one line of the network.
/// </summary>
public record RouteWithType : Route
{
    /// <summary>
    /// The type of the route (bus, tram, etc.)
    /// </summary>
    [JsonPropertyName("routeType")]
    public string RouteType { get; init; }
}

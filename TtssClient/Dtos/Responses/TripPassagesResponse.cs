using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace TtssClient.Dtos.Responses;

public record TripPassagesResponse : IResponse<TripPassagesResponse>
{
    [JsonPropertyName("actual")] public List<TripPassage> Actual { get; init; }
    [JsonPropertyName("directionText")] public string DirectionText { get; init; }
    [JsonPropertyName("old")] public List<TripPassage> Old { get; init; }

    /// <summary>
    /// The name of the route to customers.
    /// </summary>
    [JsonPropertyName("routeName")]
    public string RouteName { get; init; }

    public static JsonTypeInfo<TripPassagesResponse> TypeInfo { get; } = JsonSerializers.Default.TripPassagesResponse;
}

public record TripPassage
{
    [JsonPropertyName("actualTime")] public string? ActualTime { get; init; }
    [JsonPropertyName("plannedTime")] public string? PlannedTime { get; init; }

    /// <summary>
    /// DEPARTED, PLANNED or PREDICTED.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; init; }

    [JsonPropertyName("stop")] public TripPassageStop Stop { get; init; }

    /// <summary>
    /// The number of the stop in the sequence of all stops of the route of the trip.
    /// </summary>
    [JsonPropertyName("stop_seq_num")]
    public string SequenceNumberOfStop { get; init; }
}

public record TripPassageStop
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
    [JsonPropertyName("shortName")]
    public string ShortName { get; init; }
}

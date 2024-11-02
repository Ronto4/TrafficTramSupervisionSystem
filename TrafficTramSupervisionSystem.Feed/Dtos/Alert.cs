using System.Text.Json.Serialization;

namespace TrafficTramSupervisionSystem.Feed.Dtos;

public record Alert
{
    /// <summary>
    /// The content of the alert.
    /// </summary>
    [JsonPropertyName("title")] public string Message { get; init; }
}

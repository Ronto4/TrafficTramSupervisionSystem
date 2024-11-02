using System.Text.Json.Serialization;

namespace TrafficTramSupervisionSystem.Feed.ModelsV0;

public record Passage
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }
    
    [JsonPropertyName("old")]
    public bool? IsOld { get; init; }
    
    [JsonPropertyName("status")]
    public Status? Status { get; init; }
    
    [JsonPropertyName("plannedTime")]
    public DateOnly? PlannedTime { get; init; }
    
    // [JsonPropertyName("actualTime")]
    
}

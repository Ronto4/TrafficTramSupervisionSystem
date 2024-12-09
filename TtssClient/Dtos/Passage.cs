using System.Text.Json.Serialization;

namespace TtssClient.Dtos;

public record Passage
{
    [JsonPropertyName("passageid")] public string PassageId { get; set; }

    [JsonPropertyName("actualRelativeTime")]
    public int ActualRelativeTime { get; init; }

    [JsonPropertyName("actualTime")] public string? ActualTime { get; init; }
    [JsonPropertyName("direction")] public string Direction { get; init; }
    [JsonPropertyName("mixedTime")] public string MixedTime { get; init; }
    [JsonPropertyName("patternText")] public string? PatternText { get; init; }
    [JsonPropertyName("plannedTime")] public string PlannedTime { get; init; }
    [JsonPropertyName("routeId")] public string RouteId { get; init; }
    [JsonPropertyName("status")] public string Status { get; init; }
    [JsonPropertyName("tripId")] public string TripId { get; init; }
    [JsonPropertyName("vehicleId")] public string? VehicleId { get; init; }
    [JsonPropertyName("vias")] public List<string>? Vias { get; init; }
}

using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace TtssClient.Dtos.Responses;

public record SearchStopsResponse : IResponse<SearchStopsResponse>
{
    [JsonPropertyName("results")]
    public List<FoundStop> FoundStops { get; set; }

    public static JsonTypeInfo<SearchStopsResponse> TypeInfo { get; } = JsonSerializers.Default.SearchStopsResponse;
}

public record FoundStop
{
    [JsonPropertyName("stop")]
    public string StopShortName { get; init; }

    [JsonPropertyName("stopPassengerName")]
    public string StopName { get; init; }
}

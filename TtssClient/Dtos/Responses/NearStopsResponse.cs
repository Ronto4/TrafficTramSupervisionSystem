using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace TtssClient.Dtos.Responses;

public class NearStopsResponse : List<NearStopItem>, IResponse<NearStopsResponse>
{
    public static JsonTypeInfo<NearStopsResponse> TypeInfo { get; } = JsonSerializers.Default.NearStopsResponse;
}

public class NearStopItem
{
    [JsonPropertyName("name")] public string Name { get; init; }

    [JsonPropertyName("type")] public string Type { get; init; }

    /// <summary>
    /// Only populated in stop items.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    /// <summary>
    /// Only populated in divider items.
    /// </summary>
    [JsonPropertyName("count")]
    public int? Count { get; init; }
}

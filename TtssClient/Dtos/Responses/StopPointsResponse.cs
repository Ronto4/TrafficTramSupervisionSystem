using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace TtssClient.Dtos.Responses;

public record StopPointsResponse : IResponse<StopPointsResponse>
{
    [JsonPropertyName("stopPoints")]
    public List<StopPoint> StopPoints { get; init; }

    public static JsonTypeInfo<StopPointsResponse> TypeInfo { get; } = JsonSerializers.Default.StopPointsResponse;
}

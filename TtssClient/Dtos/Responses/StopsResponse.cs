using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace TtssClient.Dtos.Responses;

/// <summary>
/// The result of asking for all <see cref="Stop"/>s in the given area.
/// </summary>
public record StopsResponse : IResponse<StopsResponse>
{
    /// <summary>
    /// All available <see cref="Stop"/>s.
    /// </summary>
    [JsonPropertyName("stops")] public List<Stop> Stops { get; init; }

    public static JsonTypeInfo<StopsResponse> TypeInfo { get; } = JsonSerializers.Default.StopsResponse;
}

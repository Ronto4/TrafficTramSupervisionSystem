using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace TrafficTramSupervisionSystem.Feed.Dtos.Responses;

public record RoutesResponse : IResponse<RoutesResponse>
{
    [JsonPropertyName("routes")] public List<Route> Routes { get; init; }
    public static JsonTypeInfo<RoutesResponse> TypeInfo { get; } = JsonSerializers.Default.RoutesResponse;
}

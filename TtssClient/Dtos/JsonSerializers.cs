using System.Text.Json.Serialization;
using TtssClient.Dtos.Responses;

namespace TtssClient.Dtos;

[JsonSerializable(typeof(StopsResponse))]
[JsonSerializable(typeof(StopPassagesResponse))]
[JsonSerializable(typeof(SearchStopsResponse))]
[JsonSerializable(typeof(NearStopsResponse))]
[JsonSerializable(typeof(StopPointsResponse))]
[JsonSerializable(typeof(TripPassagesResponse))]
[JsonSerializable(typeof(RoutesResponse))]
[JsonSerializable(typeof(RouteStopsResponse))]
[JsonSerializable(typeof(PathsResponse))]
[JsonSerializable(typeof(VehicleResponse))]
internal partial class JsonSerializers : JsonSerializerContext;

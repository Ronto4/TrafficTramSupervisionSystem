using System.Text.Json.Serialization;
using TrafficTramSupervisionSystem.Feed.Dtos.Responses;

namespace TrafficTramSupervisionSystem.Feed.Dtos;

[JsonSerializable(typeof(StopsResponse))]
[JsonSerializable(typeof(StopPassagesResponse))]
[JsonSerializable(typeof(SearchStopsResponse))]
[JsonSerializable(typeof(NearStopsResponse))]
[JsonSerializable(typeof(StopPointsResponse))]
[JsonSerializable(typeof(TripPassagesResponse))]
[JsonSerializable(typeof(RoutesResponse))]
[JsonSerializable(typeof(RouteStopsResponse))]
internal partial class JsonSerializers : JsonSerializerContext;

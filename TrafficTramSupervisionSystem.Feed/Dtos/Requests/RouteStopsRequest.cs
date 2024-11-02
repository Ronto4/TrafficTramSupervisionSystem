using R4Uri;

namespace TrafficTramSupervisionSystem.Feed.Dtos.Requests;

public record RouteStopsRequest : IRequest
{
    public required string RouteId { get; init; }
    public R4UriQuery AppendToUri(R4UriPath uri) => uri & (routeId => RouteId) & (cacheBuster => DateTime.UtcNow.Ticks);

    public R4UriPath GetRequestPath(R4UriPath baseUri) =>
        baseUri / "internetservice" / "services" / "routeInfo" / "routeStops";
}

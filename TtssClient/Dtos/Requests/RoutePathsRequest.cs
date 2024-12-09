using R4Utils.Uri;

namespace TtssClient.Dtos.Requests;

public record RoutePathsRequest : IRequest
{
    public required string RouteId { get; init; }
    public string? Direction { get; init; }
    public R4UriQuery AppendToUri(R4UriPath uri) => uri & (id => RouteId) & (direction => Direction);

    public R4UriPath GetRequestPath(R4UriPath baseUri) =>
        baseUri / "internetservice" / "geoserviceDispatcher" / "services" / "pathinfo" / "route";
}

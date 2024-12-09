using R4Utils.Uri;

namespace TtssClient.Dtos.Requests;

public record RoutesRequest : IRequest
{
    public R4UriQuery AppendToUri(R4UriPath uri) => uri & (cacheBuster => DateTime.UtcNow.Ticks);

    public R4UriPath GetRequestPath(R4UriPath baseUri) =>
        baseUri / "internetservice" / "services" / "routeInfo" / "route";
}

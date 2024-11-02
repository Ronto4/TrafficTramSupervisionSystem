using R4Uri;

namespace TrafficTramSupervisionSystem.Feed.Dtos.Requests;

public interface IRequest
{
    public R4UriQuery AppendToUri(R4UriPath uri);

    public R4UriPath GetRequestPath(R4UriPath baseUri);

    public R4UriQuery ToUri(R4UriPath baseUri) => GetRequestPath(baseUri).AppendRequest(this);
}

public static class RequestExtensions
{
    public static R4UriQuery AppendRequest<T>(this R4UriPath uri, T request) where T : IRequest =>
        request.AppendToUri(uri);
}

using R4Uri;

namespace TrafficTramSupervisionSystem.Feed.Dtos.Requests;

public record SearchStopsRequest : IRequest
{
    public required string Search { get; init; }
    public R4UriQuery AppendToUri(R4UriPath uri) => uri & (search => Search);

    public R4UriPath GetRequestPath(R4UriPath baseUri) =>
        baseUri / "internetservice" / "services" / "lookup" / "fulltext";
}

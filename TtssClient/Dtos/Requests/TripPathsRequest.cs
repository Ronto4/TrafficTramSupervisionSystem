using R4Utils.Uri;
namespace TtssClient.Dtos.Requests;

public class TripPathsRequest : IRequest
{
    public required string TripId { get; init; }

    public R4UriQuery AppendToUri(R4UriPath uri) => uri & (tripId => TripId) & (cacheBuster => DateTime.UtcNow.Ticks);

    public R4UriPath GetRequestPath(R4UriPath baseUri) =>
        baseUri / "internetservice" / "geoserviceDispatcher" / "services" / "pathinfo" / "trip";
}

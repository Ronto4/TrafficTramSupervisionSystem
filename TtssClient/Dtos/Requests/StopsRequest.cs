using R4Utils.Uri;
using TtssClient.Models;

namespace TtssClient.Dtos.Requests;

public abstract class StopsOrStopPointsRequest : IRequest
{
    public Point TopLeft { get; init; } = new() { Latitude = -90.0, Longitude = -180.0 };
    public Point BottomRight { get; init; } = new() { Latitude = 90.0, Longitude = 180.0 };

    public R4UriQuery AppendToUri(R4UriPath uri) => uri & (left => TopLeft.TtssLongitude) &
                                                    (bottom => TopLeft.TtssLatitude) &
                                                    (right => BottomRight.TtssLongitude) &
                                                    (top => BottomRight.TtssLatitude);

    public abstract R4UriPath GetRequestPath(R4UriPath baseUri);
}

public class StopsRequest : StopsOrStopPointsRequest
{
    public override R4UriPath GetRequestPath(R4UriPath baseUri) =>
        baseUri / "internetservice" / "geoserviceDispatcher" / "services" / "stopinfo" / "stops";
}

public class StopPointsRequest : StopsOrStopPointsRequest
{
    public override R4UriPath GetRequestPath(R4UriPath baseUri) =>
        baseUri / "internetservice" / "geoserviceDispatcher" / "services" / "stopinfo" / "stopPoints";
}

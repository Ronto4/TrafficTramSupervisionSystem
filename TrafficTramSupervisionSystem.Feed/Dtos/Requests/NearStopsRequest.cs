using System.Globalization;
using R4Uri;
using TrafficTramSupervisionSystem.Feed.Models;

namespace TrafficTramSupervisionSystem.Feed.Dtos.Requests;

public record NearStopsRequest : IRequest
{
    public required Point Centre { get; init; }

    public R4UriQuery AppendToUri(R4UriPath uri) => uri &
                                                    (lat => Centre.Latitude.ToString(CultureInfo.InvariantCulture)) &
                                                    (lon => Centre.Longitude.ToString(CultureInfo.InvariantCulture));

    public R4UriPath GetRequestPath(R4UriPath baseUri) => baseUri / "internetservice" / "services" / "lookup" /
                                                          "autocomplete" / "nearStops" / "json";
}

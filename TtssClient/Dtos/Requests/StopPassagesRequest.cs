using R4Utils.Uri;
using TtssClient.Models;

namespace TtssClient.Dtos.Requests;

public abstract record StopOrStopPointPassagesRequest : IRequest
{
    /// <summary>
    /// The short name (i.e. number) of the stop or the stop code.
    /// </summary>
    public required string StopName { get; init; }
    public string PassageModeString { get; private init; } = null!; // Will be set by PassageMode.

    public required Mode PassageMode
    {
        init
        {
            PassageModeString = value switch
            {
                Mode.Arrivals => "arrival",
                Mode.Departure => "departure",
                _ => throw new ArgumentOutOfRangeException(nameof(PassageMode), value, "Invalid value")
            };
        }
    }

    public string? Authority { get; init; }
    public string? RouteId { get; init; }

    public string? Direction { get; init; }

    /// <summary>
    /// Must be a whole number. Anything above two hours is ignored.
    /// <br/><br/>
    /// Defaults to two hours.
    /// </summary>
    public TimeSpan LatestShownDepartureTime { get; init; } = TimeSpan.FromHours(2);

    protected abstract QueryParameter StopOrStopPointQuery();

    public R4UriQuery AppendToUri(R4UriPath uri) => uri & StopOrStopPointQuery() & (authority => Authority) &
                                                    (routeId => RouteId) & (direction => Direction) &
                                                    (mode => PassageModeString) &
                                                    (timeFrame =>
                                                        int.CreateChecked(LatestShownDepartureTime.TotalMinutes)) &
                                                    (cacheBuster => DateTime.UtcNow.Ticks);

    public abstract R4UriPath GetRequestPath(R4UriPath baseUri);
}

public record StopPassagesRequest : StopOrStopPointPassagesRequest
{
    protected override QueryParameter StopOrStopPointQuery() => QueryParameter.FromExpression(stop => StopName);

    public override R4UriPath GetRequestPath(R4UriPath baseUri) =>
        baseUri / "internetservice" / "services" / "passageInfo" / "stopPassages" / "stop";
}

public record StopPointPassagesRequest : StopOrStopPointPassagesRequest
{
    protected override QueryParameter StopOrStopPointQuery() => QueryParameter.FromExpression(stopPoint => StopName);

    public override R4UriPath GetRequestPath(R4UriPath baseUri) =>
        baseUri / "internetservice" / "services" / "passageInfo" / "stopPassages" / "stopPoint";
}

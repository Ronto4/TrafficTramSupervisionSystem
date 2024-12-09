using R4Utils.Uri;

namespace TtssClient.Dtos.Requests;

public record VehicleRequest : IRequest
{
    /// <summary>
    /// Seems to be related to time, usage unknown.
    /// </summary>
    public long? LastUpdate { get; init; }
    
    /// <summary>
    /// Other documented values are <c>RAW</c>.
    /// </summary>
    public string PositionType { get; init; } = "CORRECTED";
    
    /// <summary>
    /// No other documented values are known.
    /// </summary>
    public string ColorType { get; init; } = "ROUTE_BASED";

    public R4UriQuery AppendToUri(R4UriPath uri) => uri & (lastUpdate => LastUpdate) & (positionType => PositionType) &
                                                    (colorType => ColorType);

    public R4UriPath GetRequestPath(R4UriPath baseUri) => baseUri / "internetservice" / "geoserviceDispatcher" /
                                                          "services" / "vehicleinfo" / "vehicles";
}

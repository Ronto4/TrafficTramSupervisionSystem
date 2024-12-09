using R4Utils.Uri;

namespace TtssClient.Dtos.Requests;

public record VehiclePathsRequest : IRequest
{
    public required string VehicleId { get; init; }
    public R4UriQuery AppendToUri(R4UriPath uri) => uri & (id => VehicleId);

    public R4UriPath GetRequestPath(R4UriPath baseUri) =>
        baseUri / "internetservice" / "geoserviceDispatcher" / "services" / "pathinfo" / "vehicle";
}

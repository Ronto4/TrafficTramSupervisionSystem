using R4Utils.Uri;
using TtssClient.Models;

namespace TtssClient.Dtos.Requests;

public record TripPassagesRequest : IRequest
{
    public required string TripId { get; init; }
    public string? VehicleId { get; init; }
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

    public R4UriQuery AppendToUri(R4UriPath uri) => uri & (tripId => TripId) & (mode => PassageModeString) &
                                                    (vehicleId => VehicleId) & (cacheBuster => DateTime.UtcNow.Ticks);

    public R4UriPath GetRequestPath(R4UriPath baseUri) =>
        baseUri / "internetservice" / "services" / "tripInfo" / "tripPassages";
}

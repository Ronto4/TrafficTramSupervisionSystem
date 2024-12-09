using TtssClient.Dtos.Requests;
using TtssClient.Dtos.Responses;

namespace TtssClient;

public interface ITtssApi
{
    /// <summary>
    /// The base URL of the TTSS service. Must not contain `internetservice` and a trailing slash.
    ///
    /// Example: <c>http://www.ttss.krakow.pl</c> for trams in Kraków.
    /// </summary>
    Uri BaseUri { get; init; }

    /// <summary>
    /// The language of the retrieved information. Must be the two-letter (ISO 639-1) code of the language.
    /// </summary>
    string Language { get; init; }

    Task<StopsResponse>
        GetStopsAsync(StopsRequest request, CancellationToken cancellationToken = default);

    Task<StopPointsResponse> GetStopPointsAsync(StopPointsRequest request,
        CancellationToken cancellationToken = default);

    Task<StopPassagesResponse> GetStopPassagesAsync(StopPassagesRequest request,
        CancellationToken cancellationToken = default);

    Task<StopPassagesResponse> GetStopPointPassagesAsync(StopPointPassagesRequest request,
        CancellationToken cancellationToken = default);

    Task<SearchStopsResponse>
        GetAutocompleteStopsJsonAsync(SearchStopsRequest request, CancellationToken cancellationToken = default);

    Task<NearStopsResponse> GetNearStopsAsync(NearStopsRequest request,
        CancellationToken cancellationToken = default);

    Task<TripPassagesResponse> GetTripPassagesAsync(TripPassagesRequest request,
        CancellationToken cancellationToken = default);

    Task<RoutesResponse> GetRoutesAsync(RoutesRequest request,
        CancellationToken cancellationToken = default);

    Task<RouteStopsResponse> GetRouteStopsAsync(RouteStopsRequest request,
        CancellationToken cancellationToken = default);

    Task<PathsResponse> GetRoutePathsAsync(RoutePathsRequest request,
        CancellationToken cancellationToken = default);

    Task<PathsResponse> GetVehiclePathsAsync(VehiclePathsRequest request,
        CancellationToken cancellationToken = default);

    Task<VehicleResponse> GetVehiclesAsync(VehicleRequest request,
        CancellationToken cancellationToken = default);
}
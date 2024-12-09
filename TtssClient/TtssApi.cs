using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using R4Utils.Uri;
using TtssClient.Dtos.Requests;
using TtssClient.Dtos.Responses;

namespace TtssClient;

public record TtssApi : ITtssApi
{
    public required Uri BaseUri { get; init; }
    
    public required string Language { get; init; }

    private static async Task<string> GetStringAsync(Uri uri, CancellationToken cancellationToken)
    {
        HttpClient client = new();
        var content = await client.GetAsync(uri, cancellationToken);
        if (content.StatusCode is not HttpStatusCode.OK)
            throw new HttpRequestException($"Unable to get from {uri}: {content.StatusCode}");
        var text = await content.Content.ReadAsStringAsync(cancellationToken);
        return text;
    }

    private static async Task<T> GetAsync<T>(Uri uri, JsonTypeInfo<T> jsonTypeInfo, CancellationToken cancellationToken)
    {
        var text = await GetStringAsync(uri, cancellationToken);
        var response = JsonSerializer.Deserialize(text, jsonTypeInfo);
        if (response is null) throw new NullReferenceException($"response is null for text `{text}`.");
        return response;
    }

    private async Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IRequest where TResponse : IResponse<TResponse> =>
        await GetAsync(request.ToUri(R4Uri.Create(BaseUri)) & (language => Language), TResponse.TypeInfo,
            cancellationToken);

    public async Task<StopsResponse>
        GetStopsAsync(StopsRequest request, CancellationToken cancellationToken = default) =>
        await RequestAsync<StopsRequest, StopsResponse>(request, cancellationToken);

    public async Task<StopPointsResponse> GetStopPointsAsync(StopPointsRequest request,
        CancellationToken cancellationToken = default) =>
        await RequestAsync<StopPointsRequest, StopPointsResponse>(request, cancellationToken);

    public async Task<StopPassagesResponse> GetStopPassagesAsync(StopPassagesRequest request,
        CancellationToken cancellationToken = default) =>
        await RequestAsync<StopPassagesRequest, StopPassagesResponse>(request, cancellationToken);

    public async Task<StopPassagesResponse> GetStopPointPassagesAsync(StopPointPassagesRequest request,
        CancellationToken cancellationToken = default) =>
        await RequestAsync<StopPointPassagesRequest, StopPassagesResponse>(request, cancellationToken);

    public async Task<SearchStopsResponse>
        GetAutocompleteStopsJsonAsync(SearchStopsRequest request, CancellationToken cancellationToken = default) =>
        await RequestAsync<SearchStopsRequest, SearchStopsResponse>(request, cancellationToken);

    public async Task<NearStopsResponse> GetNearStopsAsync(NearStopsRequest request,
        CancellationToken cancellationToken = default) =>
        await RequestAsync<NearStopsRequest, NearStopsResponse>(request, cancellationToken);

    public async Task<TripPassagesResponse> GetTripPassagesAsync(TripPassagesRequest request,
        CancellationToken cancellationToken = default) =>
        await RequestAsync<TripPassagesRequest, TripPassagesResponse>(request, cancellationToken);

    public async Task<RoutesResponse> GetRoutesAsync(RoutesRequest request,
        CancellationToken cancellationToken = default) =>
        await RequestAsync<RoutesRequest, RoutesResponse>(request, cancellationToken);

    public async Task<RouteStopsResponse> GetRouteStopsAsync(RouteStopsRequest request,
        CancellationToken cancellationToken = default) =>
        await RequestAsync<RouteStopsRequest, RouteStopsResponse>(request, cancellationToken);

    public async Task<PathsResponse> GetRoutePathsAsync(RoutePathsRequest request,
        CancellationToken cancellationToken = default) =>
        await RequestAsync<RoutePathsRequest, PathsResponse>(request, cancellationToken);

    public async Task<PathsResponse> GetVehiclePathsAsync(VehiclePathsRequest request,
        CancellationToken cancellationToken = default) =>
        await RequestAsync<VehiclePathsRequest, PathsResponse>(request, cancellationToken);

    public async Task<VehicleResponse> GetVehiclesAsync(VehicleRequest request,
        CancellationToken cancellationToken = default) =>
        await RequestAsync<VehicleRequest, VehicleResponse>(request, cancellationToken);
}

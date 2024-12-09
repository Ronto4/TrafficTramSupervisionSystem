using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using R4Utils.Uri;
using TtssClient.Dtos.Requests;
using TtssClient.Dtos.Responses;

namespace TtssClient;

public record TtssApi
{
    /// <summary>
    /// The base URL of the TTSS service. Must not contain `internetservice` and a trailing slash.
    ///
    /// Example: <c>http://www.ttss.krakow.pl</c> for trams in Kraków.
    /// </summary>
    public required Uri BaseUri { get; init; }

    /// <summary>
    /// The language of the retrieved information. Must be the two-letter (ISO 639-1) code of the language.
    /// </summary>
    public required string Language { get; init; }

    private static async Task<string> GetStringAsync(Uri uri)
    {
        HttpClient client = new();
        Console.WriteLine(uri);
        var content = await client.GetAsync(uri);
        if (content.StatusCode is not HttpStatusCode.OK)
            throw new HttpRequestException($"Unable to get from {uri}: {content.StatusCode}");
        var text = await content.Content.ReadAsStringAsync();
        return text;
    }

    private static async Task<T> GetAsync<T>(Uri uri, JsonTypeInfo<T> jsonTypeInfo)
    {
        var text = await GetStringAsync(uri);
        var response = JsonSerializer.Deserialize(text, jsonTypeInfo);
        if (response is null) throw new NullReferenceException($"response is null for text `{text}`.");
        return response;
    }

    private async Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest where TResponse : IResponse<TResponse> =>
        await GetAsync(request.ToUri(R4Uri.Create(BaseUri)) & (language => Language), TResponse.TypeInfo);

    public async Task<StopsResponse> GetStopsAsync(StopsRequest request) =>
        await RequestAsync<StopsRequest, StopsResponse>(request);
    
    public async Task<StopPointsResponse> GetStopPointsAsync(StopPointsRequest request) =>
        await RequestAsync<StopPointsRequest, StopPointsResponse>(request);

    public async Task<StopPassagesResponse> GetStopPassagesAsync(StopPassagesRequest request) =>
        await RequestAsync<StopPassagesRequest, StopPassagesResponse>(request);
    
    public async Task<StopPassagesResponse> GetStopPointPassagesAsync(StopPointPassagesRequest request) =>
        await RequestAsync<StopPointPassagesRequest, StopPassagesResponse>(request);

    public async Task<SearchStopsResponse>
        GetAutocompleteStopsJsonAsync(SearchStopsRequest request) =>
        await RequestAsync<SearchStopsRequest, SearchStopsResponse>(request);
    
    public async Task<NearStopsResponse> GetNearStopsAsync(NearStopsRequest request) => await RequestAsync<NearStopsRequest, NearStopsResponse>(request);

    public async Task<TripPassagesResponse> GetTripPassagesAsync(TripPassagesRequest request) =>
        await RequestAsync<TripPassagesRequest, TripPassagesResponse>(request);

    public async Task<RoutesResponse> GetRoutesAsync(RoutesRequest request) =>
        await RequestAsync<RoutesRequest, RoutesResponse>(request);

    public async Task<RouteStopsResponse> GetRouteStopsAsync(RouteStopsRequest request) =>
        await RequestAsync<RouteStopsRequest, RouteStopsResponse>(request);

    public async Task<PathsResponse> GetRoutePathsAsync(RoutePathsRequest request) =>
        await RequestAsync<RoutePathsRequest, PathsResponse>(request);

    public async Task<PathsResponse> GetVehiclePathsAsync(VehiclePathsRequest request) =>
        await RequestAsync<VehiclePathsRequest, PathsResponse>(request);

    public async Task<VehicleResponse> GetVehiclesAsync(VehicleRequest request) =>
        await RequestAsync<VehicleRequest, VehicleResponse>(request);
}


using TrafficTramSupervisionSystem.Feed;
using TrafficTramSupervisionSystem.Feed.Dtos.Requests;
using TrafficTramSupervisionSystem.Feed.Models;

var api = new TtssApi
{
    Language = "de", BaseUri = new Uri("https://www.swp-potsdam.de/"),
    TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Berlin")
};
Console.WriteLine(api);
var stops = await api.GetStopsAsync(new StopsRequest());
var stopPoints = await api.GetStopPointsAsync(new StopPointsRequest());
var passages = await api.GetStopPassagesAsync(new StopPassagesRequest
{
    PassageMode = Mode.Departure,
    StopName = "275",
});
var stopPointPassages = await api.GetStopPointPassagesAsync(new StopPointPassagesRequest
{
    PassageMode = Mode.Departure,
    StopName = "27502",
});
var autocomplete = await api.GetAutocompleteStopsJsonAsync(new SearchStopsRequest
{
    Search = "S Hau",
});

var nearStops = await api.GetNearStopsAsync(new NearStopsRequest
{
    Centre = new Point
    {
        Latitude = 52.4009244,
        Longitude = 13.0557951,
    },
});
var tripPassages = await api.GetTripPassagesAsync(new TripPassagesRequest
{
    TripId = passages.Actual[0].TripId,
    PassageMode = Mode.Departure,
});
var routes = await api.GetRoutesAsync(new RoutesRequest());
var routeStops = await api.GetRouteStopsAsync(new RouteStopsRequest
{
    RouteId = "2871081879556063923",
});
Console.WriteLine(routeStops.Stops.Count);
Console.WriteLine(routes);
Console.WriteLine(tripPassages);
Console.WriteLine(nearStops);
Console.WriteLine(autocomplete);
Console.WriteLine(stopPoints.StopPoints.Count);
Console.WriteLine(stops.Stops.Count);
Console.WriteLine(passages.Actual.Count);
Console.WriteLine(stopPointPassages.Actual.Count);

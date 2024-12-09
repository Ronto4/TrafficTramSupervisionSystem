
using TtssClient;
using TtssClient.Dtos.Requests;
using TtssClient.Models;

var api = new TtssApi
{
    Language = "de", BaseUri = new Uri("https://www.swp-potsdam.de/"),
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
var routePaths = await api.GetRoutePathsAsync(new RoutePathsRequest
{
    RouteId = "2871081879556063923",
});
var vehiclePaths = await api.GetVehiclePathsAsync(new VehiclePathsRequest
{
    VehicleId = "-6377097066944518015",
});
var vehicles = await api.GetVehiclesAsync(new VehicleRequest());
Console.WriteLine(vehicles.Vehicles.Count);
Console.WriteLine(vehiclePaths.Paths.Count);
Console.WriteLine(routePaths.Paths.Count);
Console.WriteLine(routeStops.Stops.Count);
Console.WriteLine(routes);
Console.WriteLine(tripPassages);
Console.WriteLine(nearStops);
Console.WriteLine(autocomplete);
Console.WriteLine(stopPoints.StopPoints.Count);
Console.WriteLine(stops.Stops.Count);
Console.WriteLine(passages.Actual.Count);
Console.WriteLine(stopPointPassages.Actual.Count);

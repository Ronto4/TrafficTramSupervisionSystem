namespace TrafficTramSupervisionSystem.Feed.ModelsV0;

public record ColorType
{
    public string Type { get; private init; }

    private ColorType(string type)
    {
        Type = type;
    }

    public static ColorType RouteBased { get; } = new("ROUTE_BASED");
}

namespace TrafficTramSupervisionSystem.Feed.ModelsV0;

public record Mode
{
    public string Type { get; private init; }

    private Mode(string type)
    {
        Type = type;
    }

    public static Mode Arrivals { get; } = new("arrival");
    public static Mode Departures { get; } = new("departure");
}

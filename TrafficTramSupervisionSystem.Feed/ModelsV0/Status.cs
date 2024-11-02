using System.Text.Json;
using System.Text.Json.Serialization;

namespace TrafficTramSupervisionSystem.Feed.ModelsV0;

public record Status
{
    internal const string DepartedString = "DEPARTED";
    internal const string PlannedString = "PLANNED";
    internal const string PredictedString = "PREDICTED";
    internal const string StoppingString = "STOPPING";
    public string StatusName { get; private init; }

    private Status(string statusName)
    {
        StatusName = statusName;
    }

    public static Status Departed { get; } = new(DepartedString);
    public static Status Planned { get; } = new(PlannedString);
    public static Status Predicted { get; } = new(PredictedString);
    public static Status Stopping { get; } = new(StoppingString);
}

internal class StatusConverter : JsonConverter<Status>
{
    public override Status? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetString() switch
        {
            Status.PlannedString => Status.Planned,
            Status.PredictedString => Status.Predicted,
            Status.StoppingString => Status.Stopping,
            Status.DepartedString => Status.Departed,
            null => null,
            var status => throw new JsonException($"Unexpected status string: {status}")
        };

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.StatusName);
}

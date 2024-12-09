using System.Text.Json.Serialization.Metadata;

namespace TtssClient.Dtos.Responses;

public interface IResponse<TSelf> where TSelf : IResponse<TSelf>
{
    internal static abstract JsonTypeInfo<TSelf> TypeInfo { get; }
}

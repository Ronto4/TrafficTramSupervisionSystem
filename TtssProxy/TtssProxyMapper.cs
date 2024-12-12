using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace TtssProxy;

public static class TtssProxyMapper
{
    public static void MapTtssRoutes(this WebApplication app, string uriPrefix) {
        app.MapGet($"{uriPrefix}/ttss-proxy/get-string", async (string uriToGet) =>
        {
            try
            {
                using var client = new HttpClient();
                return Results.Ok(await client.GetStringAsync(uriToGet));
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });
    }
}

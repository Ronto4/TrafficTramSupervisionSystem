using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace TtssProxy;

public static class TtssProxyMapper
{
    // Only included for historic reference.
    // Requests to chunking sites(?) were failing with this.
    private static async Task<IResult> StreamingProxy(string uriToGet, HttpContext context)
    {
        // Source: ChatGPT, shockingly enough...

        // Initialize HttpClient (use IHttpClientFactory in production for better performance)
        using var httpClient = new HttpClient();

        // Make the call to the remote API
        var remoteResponse = await httpClient.GetAsync(uriToGet, HttpCompletionOption.ResponseHeadersRead);

        // Copy status code
        context.Response.StatusCode = (int)remoteResponse.StatusCode;

        // Copy headers
        foreach (var header in remoteResponse.Headers)
        {
            context.Response.Headers[header.Key] = header.Value.ToArray();
        }

        foreach (var header in remoteResponse.Content.Headers)
        {
            context.Response.Headers[header.Key] = header.Value.ToArray();
        }

        // CORS allow all. That's why this proxy exists in the first place.
        context.Response.Headers.AccessControlAllowOrigin = "*";
        context.Response.Headers.AccessControlAllowHeaders = "*";
        context.Response.Headers.AccessControlAllowMethods = "*";

        // Stream the content directly to the client
        var responseStream = await remoteResponse.Content.ReadAsStreamAsync();
        return Results.Stream(responseStream, remoteResponse.Content.Headers.ContentType?.ToString());
    }

    private static async Task<string> Proxy(string uriToGet, HttpContext context)
    {
        // Initialize HttpClient (use IHttpClientFactory in production for better performance)
        using var httpClient = new HttpClient();

        // Make the call to the remote API
        var remoteResponse = await httpClient.GetAsync(uriToGet, HttpCompletionOption.ResponseHeadersRead);

        // Copy status code
        context.Response.StatusCode = (int)remoteResponse.StatusCode;

        // Copy only some headers
        context.Response.Headers.ContentType = remoteResponse.Content.Headers.ContentType?.ToString();
        context.Response.Headers.ContentLength = remoteResponse.Content.Headers.ContentLength;
        context.Response.Headers.ContentEncoding = remoteResponse.Content.Headers.ContentEncoding.ToString();

        // CORS allow all. That's why this proxy exists in the first place.
        context.Response.Headers.AccessControlAllowOrigin = "*";
        context.Response.Headers.AccessControlAllowHeaders = "*";
        context.Response.Headers.AccessControlAllowMethods = "*";

        var responseText = await remoteResponse.Content.ReadAsStringAsync();
        return responseText;
    }

    public static void MapTtssRoutes(this WebApplication app, string uriPrefix) =>
        app.MapGet($"{uriPrefix}/ttss-proxy/get-string", async (string uriToGet, HttpContext context) =>
        {
            try
            {
                return await Proxy(uriToGet, context);
            }
            catch (Exception e)
            {
                var exceptionText = e.Message;
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "text/plain";
                context.Response.ContentLength = exceptionText.Length;
                return exceptionText;
                // Same comment as at top of file applies.
                // return Results.Problem(e.Message, statusCode: StatusCodes.Status400BadRequest);
            }
        });
}

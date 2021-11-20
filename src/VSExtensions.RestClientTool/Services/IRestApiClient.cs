namespace VSExtensions.RestClientTool.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides operations for invoking REST endpoints.
    /// </summary>
    internal interface IRestApiClient
    {
        /// <summary>
        /// Sends an HTTP request.
        /// </summary>
        /// <param name="message">The HTTP request message to send.</param>
        /// <returns>Response body.</returns>
        Task<string> SendAsync(HttpRequestMessage message);
    }
}

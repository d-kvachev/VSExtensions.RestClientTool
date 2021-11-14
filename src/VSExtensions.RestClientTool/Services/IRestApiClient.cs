namespace VSExtensions.RestClientTool.Services
{
    using System.Threading.Tasks;

    /// <summary>
    /// Provides operations for invoking REST endpoints.
    /// </summary>
    internal interface IRestApiClient
    {
        /// <summary>
        /// Sends an HTTP GET request to the specified URI.
        /// </summary>
        /// <param name="requestUri">Request URI.</param>
        /// <returns>Response body.</returns>
        Task<string> GetAsync(string requestUri);
    }
}

﻿namespace VSExtensions.RestClientTool.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// REST client used for invoking endpoints.
    /// </summary>
    internal class RestApiClient : IRestApiClient
    {
        /// <inheritdoc />
        public async Task<string> GetAsync(string requestUri)
        {
            using (var client = GetHttpClient())
            using (var response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Returns an instance of the <see cref="HttpClient"/> class.
        /// </summary>
        /// <returns>An instance of the client.</returns>
        private HttpClient GetHttpClient() => new HttpClient();
    }
}

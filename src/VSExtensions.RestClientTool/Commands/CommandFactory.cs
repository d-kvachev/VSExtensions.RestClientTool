namespace VSExtensions.RestClientTool.Commands
{
    using System.Windows.Input;

    using VSExtensions.RestClientTool.Context.Abstractions;
    using VSExtensions.RestClientTool.Services;

    /// <summary>
    /// A factory used to get instances of commands.
    /// </summary>
    internal static class CommandFactory
    {
        /// <summary>
        /// Returns an instance of the command to send the request.
        /// </summary>
        /// <param name="request">Request data context.</param>
        /// <param name="response">Response data context.</param>
        /// <returns>An instance of the command.</returns>
        public static ICommand SendRequest(IRequestDataContext request, IResponseDataContext response)
        {
            var restApiClient = new RestApiClient();
            return new SendRequestCommand(restApiClient, request, response);
        }

        /// <summary>
        /// Returns an instance of the command to add a new query parameter to the request data.
        /// </summary>
        /// <param name="queryParameters">Query parameters data context.</param>
        /// <returns>An instance of the command.</returns>
        public static ICommand AddQueryParameter(IQueryParametersDataContext queryParameters) => new QueryParameters.AddCommand(queryParameters);

        /// <summary>
        /// Returns an instance of the command to remove all disabled query parameters from the request data.
        /// </summary>
        /// <param name="queryParameters">Query parameters data context.</param>
        /// <returns>An instance of the command.</returns>
        public static ICommand RemoveDisabledParameters(IQueryParametersDataContext queryParameters) => new QueryParameters.RemoveDisabledCommand(queryParameters);

        /// <summary>
        /// Returns an instance of the command to add a new HTTP header to the request data.
        /// </summary>
        /// <param name="queryParameters">HTTP headers data context.</param>
        /// <returns>An instance of the command.</returns>
        public static ICommand AddHeader(IHttpHeadersDataContext headers) => new HttpHeaders.AddCommand(headers);

        /// <summary>
        /// Returns an instance of the command to remove all disabled HTTP headers from the request data.
        /// </summary>
        /// <param name="queryParameters">HTTP headers data context.</param>
        /// <returns>An instance of the command.</returns>
        public static ICommand RemoveDisabledHeaders(IHttpHeadersDataContext headers) => new HttpHeaders.RemoveDisabledCommand(headers);
    }
}

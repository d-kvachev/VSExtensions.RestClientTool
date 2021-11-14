namespace VSExtensions.RestClientTool.Commands
{
    using System.Windows.Input;

    using VSExtensions.RestClientTool.Abstractions;
    using VSExtensions.RestClientTool.Services;

    /// <summary>
    /// A factory used to get instances of commands.
    /// </summary>
    internal static class CommandFactory
    {
        /// <summary>
        /// Returns an instance of the command to send the request.
        /// </summary>
        /// <param name="request">Contains request parameters.</param>
        /// <param name="response">Contains response data.</param>
        /// <returns>An instance of the command.</returns>
        public static ICommand SendRequest(IRequestParameters request, IResponseData response)
        {
            var restApiClient = new RestApiClient();
            return new SendRequestCommand(restApiClient, request, response);
        }
    }
}

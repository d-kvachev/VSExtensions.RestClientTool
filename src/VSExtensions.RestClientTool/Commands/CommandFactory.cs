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
        /// <param name="request">The request data.</param>
        /// <returns>An instance of the command.</returns>
        public static ICommand SendRequest(IRequestData request)
        {
            var restApiClient = new RestApiClient();
            return new SendRequestCommand(restApiClient, request);
        }
    }
}

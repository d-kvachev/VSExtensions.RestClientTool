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
    }
}

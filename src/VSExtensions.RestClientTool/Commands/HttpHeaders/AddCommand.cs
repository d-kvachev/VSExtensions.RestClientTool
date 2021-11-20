namespace VSExtensions.RestClientTool.Commands.HttpHeaders
{
    using VSExtensions.RestClientTool.Context.Abstractions;
    using VSExtensions.RestClientTool.Models;

    /// <summary>
    /// Represents a command that adds a new HTTP header to the request data.
    /// </summary>
    internal class AddCommand : CommandBase
    {
        /// <summary>
        /// Request headers data context.
        /// </summary>
        private readonly IHttpHeadersDataContext _headers;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCommand"/> class.
        /// </summary>
        /// <param name="headers">Request headers data context.</param>
        public AddCommand(IHttpHeadersDataContext headers) => _headers = headers;

        /// <inheritdoc />
        public override bool CanExecute(object parameter) => true;

        /// <inheritdoc />
        public override void Execute(object parameter)
        {
            var newHeader = new HttpHeader(true);
            _headers.Add(newHeader);
        }
    }
}

namespace VSExtensions.RestClientTool.Commands.HttpHeaders
{
    using System.Linq;

    using VSExtensions.RestClientTool.Context.Abstractions;

    /// <summary>
    /// Represents a command that clears out all disabled HTTP headers from request data.
    /// </summary>
    internal class RemoveDisabledCommand : CommandBase
    {
        /// <summary>
        /// Request headers data context.
        /// </summary>
        private readonly IHttpHeadersDataContext _headers;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCommand"/> class.
        /// </summary>
        /// <param name="headers">Request headers data context.</param>
        public RemoveDisabledCommand(IHttpHeadersDataContext headers) => _headers = headers;

        /// <inheritdoc />
        public override bool CanExecute(object parameter) => true;

        /// <inheritdoc />
        public override void Execute(object parameter)
        {
            var disabled = _headers.Enumerate().Where(h => !h.Enabled);
            _headers.RemoveRange(disabled);
        }
    }
}

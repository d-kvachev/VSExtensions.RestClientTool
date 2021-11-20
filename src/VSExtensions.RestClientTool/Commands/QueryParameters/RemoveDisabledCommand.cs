namespace VSExtensions.RestClientTool.Commands.QueryParameters
{
    using System.Linq;

    using VSExtensions.RestClientTool.Commands;
    using VSExtensions.RestClientTool.Context.Abstractions;

    /// <summary>
    /// Represents a command that removes all disabled query parameters from the request data.
    /// </summary>
    internal class RemoveDisabledCommand : CommandBase
    {
        /// <summary>
        /// Query parameters data context.
        /// </summary>
        private readonly IQueryParametersDataContext _queryParameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveDisabledCommand"/> class.
        /// </summary>
        /// <param name="parameters">Query parameters data context.</param>
        public RemoveDisabledCommand(IQueryParametersDataContext queryParameters) => _queryParameters = queryParameters;

        /// <inheritdoc />
        public override bool CanExecute(object parameter) => true;

        /// <inheritdoc />
        public override void Execute(object parameter)
        {
            var disabled = _queryParameters.Enumerate().Where(p => !p.Enabled);
            _queryParameters.RemoveRange(disabled);
        }
    }
}

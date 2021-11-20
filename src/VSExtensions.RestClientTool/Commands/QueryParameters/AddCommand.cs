namespace VSExtensions.RestClientTool.Commands.QueryParameters
{
    using VSExtensions.RestClientTool.Context.Abstractions;
    using VSExtensions.RestClientTool.Models.Request;

    /// <summary>
    /// Represents a command that adds a new query parameter to the request data.
    /// </summary>
    internal class AddCommand : CommandBase
    {
        /// <summary>
        /// Query parameters data context.
        /// </summary>
        private readonly IQueryParametersDataContext _queryParameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddCommand"/> class.
        /// </summary>
        /// <param name="parameters">Query parameters data context.</param>
        public AddCommand(IQueryParametersDataContext queryParameters) => _queryParameters = queryParameters;

        /// <inheritdoc />
        public override bool CanExecute(object parameter) => true;

        /// <inheritdoc />
        public override void Execute(object parameter)
        {
            var newParameter = new QueryParameter(true);
            _queryParameters.Add(newParameter);
        }
    }
}

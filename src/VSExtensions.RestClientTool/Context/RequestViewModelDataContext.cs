namespace VSExtensions.RestClientTool.Context
{
    using VSExtensions.RestClientTool.Context.Abstractions;
    using VSExtensions.RestClientTool.Models.Request;
    using VSExtensions.RestClientTool.ViewModels;
    using VSExtensions.RestClientTool.ViewModels.Body;
    using VSExtensions.RestClientTool.ViewModels.HttpHeaders;
    using VSExtensions.RestClientTool.ViewModels.QueryParameters;

    /// <summary>
    /// A request data context that uses a view model as an underlying data source.
    /// </summary>
    internal class RequestViewModelDataContext : IRequestDataContext<RequestViewModel>
    {
        /// <summary>
        /// Query parameters data context
        /// </summary>
        private readonly IQueryParametersDataContext<QueryParametersViewModel> _queryParameters = new QueryParametersViewModelDataContext();

        /// <summary>
        /// HTTP headers data context.
        /// </summary>
        private readonly IHttpHeadersDataContext<HttpHeadersViewModel> _httpHeaders = new HttpHeadersViewModelDataContext();

        /// <summary>
        /// Body data context.
        /// </summary>
        private readonly IBodyDataContext<BodyViewModel> _body = new BodyViewModelDataContext();

        /// <summary>
        /// The request view model that is used as the data source.
        /// </summary>
        private RequestViewModel _viewModel;

        /// <inheritdoc />
        public IQueryParametersDataContext QueryParameters => _queryParameters;

        /// <inheritdoc />
        public IHttpHeadersDataContext HttpHeaders => _httpHeaders;

        /// <inheritdoc />
        public IBodyDataContext Body => _body;

        /// <inheritdoc />
        public void Initialize(RequestViewModel dataSource)
        {
            _viewModel = dataSource;

            _queryParameters.Initialize(dataSource.QueryParameters);
            _httpHeaders.Initialize(dataSource.HttpHeaders);
            _body.Initialize(dataSource.Body);
        }

        /// <inheritdoc />
        public RequestSettings GetSettings() => new RequestSettings(_viewModel.RequestType, _viewModel.RequestUri);
    }
}

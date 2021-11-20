namespace VSExtensions.RestClientTool.Context
{
    using VSExtensions.RestClientTool.Context.Abstractions;
    using VSExtensions.RestClientTool.ViewModels;

    /// <summary>
    /// A rest client tool data context that uses a view model as an underlying data source.
    /// </summary>
    internal class RestClientToolViewModelDataContext : IRestClientToolDataContext<RestClientToolWindowViewModel>
    {
        /// <summary>
        /// Request data context.
        /// </summary>
        private readonly IRequestDataContext<RequestViewModel> _request = new RequestViewModelDataContext();

        /// <summary>
        /// Response data context.
        /// </summary>
        private readonly IResponseDataContext<ResponseViewModel> _response = new ResponseViewModelDataContext();

        /// <inheritdoc />
        public IRequestDataContext Request => _request;

        /// <inheritdoc />
        public IResponseDataContext Response => _response;

        /// <inheritdoc />
        public void Initialize(RestClientToolWindowViewModel dataSource)
        {
            _request.Initialize(dataSource.RequestViewModel);
            _response.Initialize(dataSource.ResponseViewModel);
        }
    }
}

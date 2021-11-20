namespace VSExtensions.RestClientTool.Context
{
    using VSExtensions.RestClientTool.Context.Abstractions;
    using VSExtensions.RestClientTool.Models;
    using VSExtensions.RestClientTool.ViewModels;

    /// <summary>
    /// A request data context that uses a view model as an underlying data source.
    /// </summary>
    internal class RequestViewModelDataContext : IRequestDataContext<RequestViewModel>
    {
        /// <summary>
        /// The request view model that is used as the data source.
        /// </summary>
        private RequestViewModel _viewModel;

        /// <inheritdoc />
        public void Initialize(RequestViewModel dataSource) => _viewModel = dataSource;

        /// <inheritdoc />
        public RequestSettings GetSettings() => new RequestSettings(_viewModel.RequestType, _viewModel.RequestUri);
    }
}

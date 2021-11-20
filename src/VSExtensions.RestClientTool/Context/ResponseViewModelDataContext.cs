namespace VSExtensions.RestClientTool.Context
{
    using VSExtensions.RestClientTool.Context.Abstractions;
    using VSExtensions.RestClientTool.Models;
    using VSExtensions.RestClientTool.ViewModels;

    /// <summary>
    /// A response data context that uses a view model as an underlying data source.
    /// </summary>
    internal class ResponseViewModelDataContext : IResponseDataContext<ResponseViewModel>
    {
        /// <summary>
        /// The response view model that is used as the data source.
        /// </summary>
        private ResponseViewModel _viewModel;

        /// <inheritdoc />
        public void Initialize(ResponseViewModel dataSource) => _viewModel = dataSource;

        /// <inheritdoc />
        public void SetData(ResponseData data) => _viewModel.ResponseBody = data.Body;
    }
}

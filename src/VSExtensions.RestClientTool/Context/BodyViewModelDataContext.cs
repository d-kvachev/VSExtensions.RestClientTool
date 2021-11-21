namespace VSExtensions.RestClientTool.Context
{
    using System;
    using System.Net.Http;

    using VSExtensions.RestClientTool.Context.Abstractions;
    using VSExtensions.RestClientTool.Models.Content;
    using VSExtensions.RestClientTool.ViewModels.Body;

    /// <summary>
    /// A request body data context that uses a view model as an underlying data source.
    /// </summary>
    internal class BodyViewModelDataContext : IBodyDataContext<BodyViewModel>
    {
        /// <summary>
        /// The request body view model that is used as the data source.
        /// </summary>
        private BodyViewModel _viewModel;

        /// <inheritdoc />
        public void Initialize(BodyViewModel dataSource) => _viewModel = dataSource;

        /// <inheritdoc />
        public bool HasContent => _viewModel.Content.Type != ContentType.None;

        /// <inheritdoc />
        public HttpContent GetHttpContent()
        {
            var content = GetContent();
            return content.GetHttpContent();
        }

        /// <summary>
        /// Returns an <see cref="IContent"/> instance based on the content stored in the view model.
        /// </summary>
        /// <returns>An <see cref="IContent"/> instance.</returns>
        private IContent GetContent()
        {
            switch (_viewModel.Content.Type)
            {
                case ContentType.None:
                    return CreateEmptyContent();
                case ContentType.Json:
                    return CreateJsonContent(_viewModel.Content);
                default:
                    throw new NotSupportedException($"The '{_viewModel.Content.Type}' content type is not supported");
            }
        }

        /// <summary>
        /// Returns the <see cref="EmptyContent"/> class instance.
        /// </summary>
        /// <returns>The <see cref="EmptyContent"/> class instance.</returns>
        private IContent CreateEmptyContent() => new EmptyContent();

        /// <summary>
        /// Builds and returns the <see cref="JsonContent"/> based on data stored in the view model.
        /// </summary>
        /// <param name="content">Content view model.</param>
        /// <returns>The <see cref="JsonContent"/> class instance.</returns>
        private IContent CreateJsonContent(ContentViewModelBase content)
        {
            return content is JsonContentViewModel jsonContentVm
                ? new JsonContent(jsonContentVm.Text)
                : throw new ArgumentException("Invalid view model type. JSON content is expected", nameof(content));
        }
    }
}

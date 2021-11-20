namespace VSExtensions.RestClientTool.Context
{
    using System.Collections.Generic;
    using System.Linq;

    using VSExtensions.RestClientTool.Context.Abstractions;
    using VSExtensions.RestClientTool.Models;
    using VSExtensions.RestClientTool.ViewModels.HttpHeaders;

    /// <summary>
    /// An HTTP headers data context that uses a view model as an underlying data source.
    /// </summary>
    internal class HttpHeadersViewModelDataContext : IHttpHeadersDataContext<HttpHeadersViewModel>
    {
        /// <summary>
        /// The HTTP headers view model that is used as the data source.
        /// </summary>
        private HttpHeadersViewModel _viewModel;

        /// <inheritdoc />
        public void Initialize(HttpHeadersViewModel dataSource) => _viewModel = dataSource;

        /// <inheritdoc />
        public void Add(HttpHeader header)
        {
            var headerVm = ToViewModel(header);
            _viewModel.Headers.Add(headerVm);
        }

        /// <inheritdoc />
        public IEnumerable<HttpHeader> Enumerate() => _viewModel.Headers.Select(ToHttpHeader).ToList();

        /// <inheritdoc />
        public void RemoveRange(IEnumerable<HttpHeader> headers)
        {
            var headersToRemove = _viewModel.Headers
                .Where(hvm => headers.Any(h => hvm.Enabled == h.Enabled && hvm.Key == h.Key))
                .ToList();

            foreach (var toRemove in headersToRemove)
                _viewModel.Headers.Remove(toRemove);
        }

        /// <summary>
        /// Converts a <see cref="HttpHeader"/> object to a <see cref="HttpHeaderViewModel"/> instance.
        /// </summary>
        /// <param name="header">A <see cref="HttpHeader"/> object.</param>
        /// <returns>A <see cref="HttpHeaderViewModel"/> instance.</returns>
        public HttpHeaderViewModel ToViewModel(HttpHeader header)
        {
            return new HttpHeaderViewModel
            {
                Enabled = header.Enabled,
                Key = header.Key,
                Value = header.Value
            };
        }

        /// <summary>
        /// Converts a <see cref="HttpHeaderViewModel"/> object to a <see cref="HttpHeader"/> instance.
        /// </summary>
        /// <param name="viewModel">A <see cref="HttpHeaderViewModel"/> object.</param>
        /// <returns>A <see cref="QueryParameter"/> instance.</returns>
        public HttpHeader ToHttpHeader(HttpHeaderViewModel viewModel) =>
            new HttpHeader(viewModel.Enabled, viewModel.Key, viewModel.Value);
    }
}

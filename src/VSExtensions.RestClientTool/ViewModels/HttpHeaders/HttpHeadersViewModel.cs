namespace VSExtensions.RestClientTool.ViewModels.HttpHeaders
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using VSExtensions.RestClientTool.Commands;
    using VSExtensions.RestClientTool.Context.Abstractions;

    /// <summary>
    /// Contains logic for HTTP headers customization.
    /// </summary>
    internal class HttpHeadersViewModel
    {
        /// <summary>
        /// HTTP headers data context.
        /// </summary>
        private IHttpHeadersDataContext _context;

        /// <summary>
        /// Gets the collection of HTTP headers.
        /// </summary>
        public ObservableCollection<HttpHeaderViewModel> Headers { get; } = new ObservableCollection<HttpHeaderViewModel>();

        /// <summary>
        /// Gets a command that adds a new HTTP header to the request.
        /// </summary>
        public ICommand AddCommand => CommandFactory.AddHeader(_context);

        /// <summary>
        /// Gets a command that removes all disabled HTTP headers from the request.
        /// </summary>
        public ICommand RemoveDisabledCommand => CommandFactory.RemoveDisabledHeaders(_context);

        /// <summary>
        /// Sets headers data context.
        /// </summary>
        /// <param name="context">HTTP headers data context.</param>
        public void SetContext(IHttpHeadersDataContext context) => _context = context;
    }
}

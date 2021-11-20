namespace VSExtensions.RestClientTool.ViewModels
{
    using System.Collections.ObjectModel;

    using VSExtensions.RestClientTool.Context.Abstractions;
    using VSExtensions.RestClientTool.Models;
    using VSExtensions.RestClientTool.ViewModels.HttpHeaders;
    using VSExtensions.RestClientTool.ViewModels.QueryParameters;

    /// <summary>
    /// A request view model containing logic for request customization.
    /// </summary>
    internal class RequestViewModel : ViewModelBase
    {
        /// <summary>
        /// Selected request type.
        /// </summary>
        private RequestType _requestType;

        /// <summary>
        /// Current request URI string.
        /// </summary>
        private string _requestUri = "http://localhost:5555/";

        /// <summary>
        /// Gets available request types.
        /// </summary>
        public ObservableCollection<RequestType> AvailableRequestTypes { get; } = new ObservableCollection<RequestType>(RequestTypesProvider.Get());

        /// <summary>
        /// Gets or sets selected request type.
        /// </summary>
        public RequestType RequestType
        {
            get => _requestType;
            set
            {
                _requestType = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets current request URI string.
        /// </summary>
        public string RequestUri
        {
            get => _requestUri;
            set
            {
                _requestUri = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets a query parameters view model containing logic for query customization.
        /// </summary>
        public QueryParametersViewModel QueryParameters { get; } = new QueryParametersViewModel();

        /// <summary>
        /// Gets a HTTP headers view model containing logic for HTTP headers customization.
        /// </summary>
        public HttpHeadersViewModel HttpHeaders { get; } = new HttpHeadersViewModel();

        /// <summary>
        /// Sets request data context.
        /// </summary>
        /// <param name="context">Request data context.</param>
        public void SetContext(IRequestDataContext context)
        {
            QueryParameters.SetContext(context.QueryParameters);
            HttpHeaders.SetContext(context.HttpHeaders);
        }
    }
}

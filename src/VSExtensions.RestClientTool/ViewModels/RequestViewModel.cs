namespace VSExtensions.RestClientTool.ViewModels
{
    using System.Collections.ObjectModel;

    using VSExtensions.RestClientTool.Models;

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
    }
}

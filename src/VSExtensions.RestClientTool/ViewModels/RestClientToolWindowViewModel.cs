namespace VSExtensions.RestClientTool.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    using VSExtensions.RestClientTool.Abstractions;
    using VSExtensions.RestClientTool.Commands;
    using VSExtensions.RestClientTool.Models;

    /// <summary>
    /// The main user control view model.
    /// </summary>
    internal class RestClientToolWindowViewModel : INotifyPropertyChanged, IRequestData
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
        /// The body of the response received after the request was sent
        /// </summary>
        private string _responseBody;

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets available request types.
        /// </summary>
        public IReadOnlyCollection<RequestType> AvailableRequestTypes => RequestTypesProvider.Get();

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
        /// Gets or sets the body of the response received after the request was sent.
        /// </summary>
        public string ResponseBody
        {
            get => _responseBody;
            set
            {
                _responseBody = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets a command that sends a request to an endpoint.
        /// </summary>
        public ICommand SendRequestCommand => CommandFactory.SendRequest(this);

        /// <summary>
        /// Safely invokes the <see cref="PropertyChanged"/> event.
        /// </summary>
        private void OnPropertyChanged([CallerMemberName] string propertyName = default) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

namespace VSExtensions.RestClientTool.Commands
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Newtonsoft.Json;

    using VSExtensions.RestClientTool.Abstractions;
    using VSExtensions.RestClientTool.Models;
    using VSExtensions.RestClientTool.Services;

    /// <summary>
    /// Represents a command that sends a request to an endpoint.
    /// </summary>
    internal class SendRequestCommand : ICommand
    {
        /// <summary>
        /// REST client used for invoking endpoints.
        /// </summary>
        private readonly IRestApiClient _restApiClient;

        /// <summary>
        /// Contains request data.
        /// </summary>
        private readonly IRequestData _request;

        /// <summary>
        /// Specifies that a request is currently being sent.
        /// </summary>
        private bool _requestInProgress;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendRequestCommand"/> class.
        /// </summary>
        /// <param name="restApiClient">REST client used for invoking endpoints.</param>
        /// <param name="request">Contains request data.</param>
        public SendRequestCommand(IRestApiClient restApiClient, IRequestData request)
        {
            _restApiClient = restApiClient;
            _request = request;
        }

        /// <inheritdoc />
        public event EventHandler CanExecuteChanged;

        /// <inheritdoc />
        public bool CanExecute(object parameter) => !_requestInProgress;

        /// <inheritdoc />
        [SuppressMessage("Usage", "VSTHRD100:Avoid async void methods", Justification = "All exceptions are handled")]
        public async void Execute(object parameter)
        {
            _requestInProgress = true;
            OnCanExecuteChanged();

            try
            {
                // Invoking the CanExecuteChanged event requires being in the UI thread, so ConfigureAwait(false) cannot be used.
                await SendRequestAsync();
            }
            catch (Exception ex)
            {
                _request.ResponseBody = ex.Message;
            }
            finally
            {
                _requestInProgress = false;
                OnCanExecuteChanged();
            }
        }

        /// <summary>
        /// Sends a request to the endpoint specified in the request data and populates the response data.
        /// </summary>
        /// <returns>A task that represents an asynchronous operation of sending the request.</returns>
        private async Task SendRequestAsync()
        {
            var uriValid = TryConvertToUri(_request.RequestUri, out var requestUri);
            if (!uriValid)
                throw new InvalidOperationException($"Invalid request URI: '{_request.RequestUri}'");

            var requestTypeSupported = _request.RequestType == RequestType.Get;
            if (!requestTypeSupported)
                throw new NotSupportedException($"Request type is not supported: '{_request.RequestType}'");

            var responseBody = await _restApiClient.GetAsync(requestUri).ConfigureAwait(false);

            _request.ResponseBody = TryIndentJson(responseBody, out var indented) ? indented : responseBody;
        }

        /// <summary>
        /// Attempts to add indentation to the json string. Fails if the provided string is not json.
        /// </summary>
        /// <param name="json">Json string.</param>
        /// <param name="indented">Indented json string.</param>
        /// <returns><c>true</c> if json is indented successfully, <c>false</c> otherwise.</returns>
        private bool TryIndentJson(string json, out string indented)
        {
            object deserialized;
            try
            {
                deserialized = JsonConvert.DeserializeObject(json);
            }
            catch (JsonReaderException)
            {
                indented = default;
                return false;
            }

            indented = JsonConvert.SerializeObject(deserialized, Formatting.Indented);
            return true;
        }

        /// <summary>
        /// Attempts to convert string representation of request URI to an actual <see cref="Uri"/> object.
        /// </summary>
        /// <param name="uriString">URI string.</param>
        /// <param name="uri">A <see cref="Uri"/> instance.</param>
        /// <returns><c>true</c> if string was successfully converted to <see cref="Uri"/>, <c>false</c> otherwise.</returns>
        private bool TryConvertToUri(string uriString, out Uri uri)
        {
            var wellFormedUri = !string.IsNullOrWhiteSpace(uriString) && Uri.IsWellFormedUriString(uriString, UriKind.Absolute);
            if (wellFormedUri)
            {
                uri = new Uri(uriString, UriKind.Absolute);
                return true;
            }

            uri = default;
            return false;
        }

        /// <summary>
        /// Safely invokes the <see cref="CanExecuteChanged"/> event.
        /// </summary>
        private void OnCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}

namespace VSExtensions.RestClientTool.Commands
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using VSExtensions.RestClientTool.Context.Abstractions;
    using VSExtensions.RestClientTool.Models;
    using VSExtensions.RestClientTool.Services;

    /// <summary>
    /// Represents a command that sends a request to an endpoint.
    /// </summary>
    internal class SendRequestCommand : CommandBase
    {
        /// <summary>
        /// REST client used for invoking endpoints.
        /// </summary>
        private readonly IRestApiClient _restApiClient;

        /// <summary>
        /// Request data context.
        /// </summary>
        private readonly IRequestDataContext _request;

        /// <summary>
        /// Response data context.
        /// </summary>
        private readonly IResponseDataContext _response;

        /// <summary>
        /// Specifies that a request is currently being sent.
        /// </summary>
        private bool _requestInProgress;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendRequestCommand"/> class.
        /// </summary>
        /// <param name="restApiClient">REST client used for invoking endpoints.</param>
        /// <param name="request">Request data context.</param>
        /// <param name="response">Response data context.</param>
        public SendRequestCommand(IRestApiClient restApiClient, IRequestDataContext request, IResponseDataContext response)
        {
            _restApiClient = restApiClient;
            _request = request;
            _response = response;
        }

        /// <inheritdoc />
        public override bool CanExecute(object parameter) => !_requestInProgress;

        /// <inheritdoc />
        [SuppressMessage("Usage", "VSTHRD100:Avoid async void methods", Justification = "All exceptions are handled")]
        public override async void Execute(object parameter)
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
                var response = new ResponseData(ex.Message);
                _response.SetData(response);
            }
            finally
            {
                _requestInProgress = false;
                OnCanExecuteChanged();
            }
        }

        /// <summary>
        /// Sends a request to the endpoint specified in the request context and populates data in the response context.
        /// </summary>
        /// <returns>A task that represents an asynchronous operation of sending the request.</returns>
        private async Task SendRequestAsync()
        {
            var settings = _request.GetSettings();

            var uriValid = TryConvertToUri(settings.Uri, out var requestUri);
            if (!uriValid)
                throw new InvalidOperationException($"Invalid request URI: '{settings.Uri}'");

            var requestTypeSupported = settings.Type == RequestType.Get;
            if (!requestTypeSupported)
                throw new NotSupportedException($"Request type is not supported: '{settings.Type}'");

            var responseBody = await _restApiClient.GetAsync(requestUri).ConfigureAwait(false);
            responseBody = TryIndentJson(responseBody, out var indented) ? indented : responseBody;

            var response = new ResponseData(responseBody);
            _response.SetData(response);
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
    }
}

namespace VSExtensions.RestClientTool.ViewModels
{
    using VSExtensions.RestClientTool.Abstractions;

    /// <summary>
    /// A response view model, containing logic for response processing.
    /// </summary>
    internal class ResponseViewModel : ViewModelBase, IResponseData
    {
        /// <summary>
        /// The body of the response received after the request was sent
        /// </summary>
        private string _responseBody;

        /// <inheritdoc />
        public string ResponseBody
        {
            get => _responseBody;
            set
            {
                _responseBody = value;
                OnPropertyChanged();
            }
        }
    }
}

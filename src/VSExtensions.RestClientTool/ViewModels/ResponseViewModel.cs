namespace VSExtensions.RestClientTool.ViewModels
{
    /// <summary>
    /// A response view model, containing logic for response processing.
    /// </summary>
    internal class ResponseViewModel : ViewModelBase
    {
        /// <summary>
        /// The body of the response received after the request was sent
        /// </summary>
        private string _responseBody;

        /// <summary>
        /// Gets or sets the body of the received response.
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
    }
}

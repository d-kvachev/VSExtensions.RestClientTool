namespace VSExtensions.RestClientTool.ViewModels.HttpHeaders
{
    /// <summary>
    /// Contains logic for configuring an HTTP header.
    /// </summary>
    internal class HttpHeaderViewModel : ViewModelBase
    {
        /// <summary>
        /// Indicates whether the header is going to be used in a request.
        /// </summary>
        private bool _enabled;

        /// <summary>
        /// The header key.
        /// </summary>
        private string _key;

        /// <summary>
        /// The header value.
        /// </summary>
        private string _value;

        /// <summary>
        /// Gets or sets a value indicating whether the header is going to be used in a request.
        /// </summary>
        public bool Enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the header key.
        /// </summary>
        public string Key
        {
            get => _key;
            set
            {
                _key = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the header value.
        /// </summary>
        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }
    }
}

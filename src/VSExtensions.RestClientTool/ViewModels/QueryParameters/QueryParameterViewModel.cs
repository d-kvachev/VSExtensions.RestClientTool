namespace VSExtensions.RestClientTool.ViewModels.QueryParameters
{
    /// <summary>
    /// Contains logic for configuring a query parameter.
    /// </summary>
    internal class QueryParameterViewModel : ViewModelBase
    {
        /// <summary>
        /// Indicates whether the query parameter is going to be used in a request.
        /// </summary>
        private bool _enabled;

        /// <summary>
        /// The query parameter key.
        /// </summary>
        private string _key;

        /// <summary>
        /// The query parameter value.
        /// </summary>
        private string _value;

        /// <summary>
        /// Gets or sets a value indicating whether the query parameter is going to be used in a request.
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
        /// Gets or sets the query parameter key.
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
        /// Gets or sets the query parameter value.
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

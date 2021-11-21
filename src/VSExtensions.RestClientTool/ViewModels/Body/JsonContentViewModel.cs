namespace VSExtensions.RestClientTool.ViewModels.Body
{
    using VSExtensions.RestClientTool.Models.Content;

    /// <summary>
    /// A JSON content view model.
    /// </summary>
    internal class JsonContentViewModel : ContentViewModelBase
    {
        /// <summary>
        /// JSON text.
        /// </summary>
        private string _text;

        /// <inheritdoc />
        public override ContentType Type => ContentType.Json;

        /// <summary>
        /// Gets or sets the JSON text.
        /// </summary>
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }
    }
}

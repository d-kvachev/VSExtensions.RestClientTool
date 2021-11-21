namespace VSExtensions.RestClientTool.ViewModels.Body
{
    /// <summary>
    /// Contains logic for request body customization.
    /// </summary>
    internal class BodyViewModel : ViewModelBase
    {
        /// <summary>
        /// Current content view model.
        /// </summary>
        private ContentViewModelBase _content = new EmptyContentViewModel();

        /// <summary>
        /// Gets the current content view model.
        /// </summary>
        public ContentViewModelBase Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }
    }
}

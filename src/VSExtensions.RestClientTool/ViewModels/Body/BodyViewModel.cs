namespace VSExtensions.RestClientTool.ViewModels.Body
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using VSExtensions.RestClientTool.Models.Content;

    /// <summary>
    /// Contains logic for request body customization.
    /// </summary>
    internal class BodyViewModel : ViewModelBase
    {
        /// <summary>
        /// Cached content view models.
        /// </summary>
        private readonly Dictionary<ContentType, ContentViewModelBase> _contentViewModels = new Dictionary<ContentType, ContentViewModelBase>();

        /// <summary>
        /// Selected content type.
        /// </summary>
        private ContentType _contentType;

        /// <summary>
        /// Current content view model.
        /// </summary>
        private ContentViewModelBase _content = new EmptyContentViewModel();

        /// <summary>
        /// Gets available content types.
        /// </summary>
        public ObservableCollection<ContentType> AvailableContentTypes { get; } = new ObservableCollection<ContentType>(ContentTypesProvider.Get());

        /// <summary>
        /// Gets or sets selected content type.
        /// </summary>
        public ContentType ContentType
        {
            get => _contentType;
            set
            {
                _contentType = value;
                ResetContent();
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the current content view model.
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

        /// <summary>
        /// Resets content view model according to the selected content type.
        /// </summary>
        private void ResetContent() => Content = GetContentViewModel(_contentType);

        /// <summary>
        /// Returns a cached version or a new instance of a view model that matches the provided content type.
        /// </summary>
        /// <param name="contentType">Content type.</param>
        /// <returns>Cached version or a new instance of content view model.</returns>
        private ContentViewModelBase GetContentViewModel(ContentType contentType)
        {
            if (_contentViewModels.ContainsKey(contentType))
                return _contentViewModels[contentType];

            var newViewModel = CreateContentViewModel(contentType);
            _contentViewModels.Add(contentType, newViewModel);

            return newViewModel;
        }

        /// <summary>
        /// Creates a new view model based on selected content type.
        /// </summary>
        /// <returns>Content view model.</returns>
        private ContentViewModelBase CreateContentViewModel(ContentType contentType)
        {
            switch (contentType)
            {
                case ContentType.None:
                    return new EmptyContentViewModel();
                case ContentType.Json:
                    return new JsonContentViewModel();
                default:
                    throw new ArgumentOutOfRangeException(nameof(contentType));
            }
        }
    }
}

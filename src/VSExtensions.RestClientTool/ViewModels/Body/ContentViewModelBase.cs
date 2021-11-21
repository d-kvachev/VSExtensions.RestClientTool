namespace VSExtensions.RestClientTool.ViewModels.Body
{
    using VSExtensions.RestClientTool.Models.Content;

    /// <summary>
    /// Base class for content customization.
    /// </summary>
    internal abstract class ContentViewModelBase : ViewModelBase
    {
        /// <summary>
        /// Gets the type of the content.
        /// </summary>
        public abstract ContentType Type { get; }
    }
}

namespace VSExtensions.RestClientTool.ViewModels.Body
{
    using VSExtensions.RestClientTool.Models.Content;

    /// <summary>
    /// An empty content view model.
    /// </summary>
    internal class EmptyContentViewModel : ContentViewModelBase
    {
        /// <inheritdoc />
        public override ContentType Type => ContentType.None;
    }
}

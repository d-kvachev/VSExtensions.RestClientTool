namespace VSExtensions.RestClientTool.Models.Content
{
    using System.Net.Http;

    /// <summary>
    /// Provides operations to process request content.
    /// </summary>
    internal interface IContent
    {
        /// <summary>
        /// Gets content type.
        /// </summary>
        ContentType Type { get; }

        /// <summary>
        /// Gets a media type of content.
        /// </summary>
        string MediaType { get; }

        /// <summary>
        /// Returns an <see cref="HttpContent"/> instance created from content data.
        /// </summary>
        /// <returns>An <see cref="HttpContent"/> instance.</returns>
        HttpContent GetHttpContent();
    }
}

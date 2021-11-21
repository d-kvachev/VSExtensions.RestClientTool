namespace VSExtensions.RestClientTool.Models.Content
{
    using System;
    using System.Net.Http;

    /// <summary>
    /// An empty content.
    /// </summary>
    internal class EmptyContent : IContent
    {
        /// <inheritdoc />
        public string MediaType { get; } = string.Empty;

        /// <inheritdoc />
        public ContentType Type { get; } = ContentType.None;

        /// <inheritdoc />
        public HttpContent GetHttpContent() => throw new InvalidOperationException("There is no content");
    }
}

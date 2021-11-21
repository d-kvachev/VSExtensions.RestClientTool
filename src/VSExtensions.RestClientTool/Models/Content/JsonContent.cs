namespace VSExtensions.RestClientTool.Models.Content
{
    using System.Net.Http;
    using System.Text;

    /// <summary>
    /// A JSON content.
    /// </summary>
    internal class JsonContent : IContent
    {
        /// <summary>
        /// JSON string content.
        /// </summary>
        private readonly string _jsonString;

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonContent"/> class.
        /// </summary>
        /// <param name="jsonString">JSON string content.</param>
        public JsonContent(string jsonString) => _jsonString = jsonString;

        /// <inheritdoc />
        public ContentType Type { get; } = ContentType.Json;

        /// <inheritdoc />
        public string MediaType { get; } = "application/json";

        /// <inheritdoc />
        public HttpContent GetHttpContent() => new StringContent(_jsonString, Encoding.UTF8, MediaType);
    }
}

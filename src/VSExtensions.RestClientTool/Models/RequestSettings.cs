namespace VSExtensions.RestClientTool.Models
{
    /// <summary>
    /// Contains settings of a request.
    /// </summary>
    internal readonly struct RequestSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestSettings"/> struct.
        /// </summary>
        /// <param name="type">Request type.</param>
        /// <param name="uri">Request URI string.</param>
        public RequestSettings(RequestType type, string uri)
        {
            Type = type;
            Uri = uri;
        }

        /// <summary>
        /// Gets a request type.
        /// </summary>
        public RequestType Type { get; }

        /// <summary>
        /// Gets a request URI string.
        /// </summary>
        public string Uri { get; }
    }
}

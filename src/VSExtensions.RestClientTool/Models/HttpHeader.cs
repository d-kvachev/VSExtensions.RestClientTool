namespace VSExtensions.RestClientTool.Models
{
    /// <summary>
    /// Contains data about a single HTTP request header.
    /// </summary>
    internal readonly struct HttpHeader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHeader"/> struct.
        /// </summary>
        /// <param name="enabled">A value indicating whether the header is going to be used in a request.</param>
        public HttpHeader(bool enabled)
            : this(enabled, string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpHeader"/> struct.
        /// </summary>
        /// <param name="enabled">A value indicating whether the header is going to be used in a request.</param>
        /// <param name="key">The key of the header.</param>
        /// <param name="value">The value of the header.</param>
        public HttpHeader(bool enabled, string key, string value)
        {
            Enabled = enabled;
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Gets a value indicating whether the header is going to be used in a request.
        /// </summary>
        public bool Enabled { get; }

        /// <summary>
        /// Gets the header key.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Gets the header value.
        /// </summary>
        public string Value { get; }
    }
}

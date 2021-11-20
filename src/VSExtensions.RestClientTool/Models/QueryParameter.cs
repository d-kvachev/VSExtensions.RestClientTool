namespace VSExtensions.RestClientTool.Models
{
    /// <summary>
    /// Contains data about a single query parameter of a request.
    /// </summary>
    internal readonly struct QueryParameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryParameter"/> struct.
        /// </summary>
        /// <param name="enabled">A value indicating whether the query parameter is going to be used in a request.</param>
        public QueryParameter(bool enabled)
            : this(enabled, string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryParameter"/> struct.
        /// </summary>
        /// <param name="enabled">A value indicating whether the query parameter is going to be used in a request.</param>
        /// <param name="key">The key of the query parameter.</param>
        /// <param name="value">The value of the query parameter.</param>
        public QueryParameter(bool enabled, string key, string value)
        {
            Enabled = enabled;
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Gets a value indicating whether the query parameter is going to be used in a request.
        /// </summary>
        public bool Enabled { get; }

        /// <summary>
        /// Gets the query parameter key.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Gets the query parameter value.
        /// </summary>
        public string Value { get; }
    }
}

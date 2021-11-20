namespace VSExtensions.RestClientTool.Models
{
    /// <summary>
    /// Contains response data.
    /// </summary>
    internal readonly struct ResponseData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseData"/> struct.
        /// </summary>
        /// <param name="body">Response body.</param>
        public ResponseData(string body)
        {
            Body = body;
        }

        /// <summary>
        /// Gets the body of the received response.
        /// </summary>
        public string Body { get; }
    }
}

namespace VSExtensions.RestClientTool.Abstractions
{
    using VSExtensions.RestClientTool.Models;

    /// <summary>
    /// Contains request data.
    /// </summary>
    internal interface IRequestData
    {
        /// <summary>
        /// Gets or sets request type.
        /// </summary>
        RequestType RequestType { get; set; }

        /// <summary>
        /// Gets or sets request URI string.
        /// </summary>
        string RequestUri { get; set; }

        /// <summary>
        /// Gets or sets the body of the response received after the request was sent.
        /// </summary>
        string ResponseBody { get; set; }
    }
}

namespace VSExtensions.RestClientTool.Abstractions
{
    using VSExtensions.RestClientTool.Models;

    /// <summary>
    /// Contains request parameters.
    /// </summary>
    internal interface IRequestParameters
    {
        /// <summary>
        /// Gets request type.
        /// </summary>
        RequestType RequestType { get; }

        /// <summary>
        /// Gets request URI string.
        /// </summary>
        string RequestUri { get; }
    }
}

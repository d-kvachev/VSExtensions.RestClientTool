namespace VSExtensions.RestClientTool.Abstractions
{
    /// <summary>
    /// Contains response data.
    /// </summary>
    internal interface IResponseData
    {
        /// <summary>
        /// Gets or sets the body of the response received after the request was sent.
        /// </summary>
        string ResponseBody { get; set; }
    }
}

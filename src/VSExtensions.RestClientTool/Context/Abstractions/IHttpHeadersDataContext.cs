namespace VSExtensions.RestClientTool.Context.Abstractions
{
    using System.Collections.Generic;

    using VSExtensions.RestClientTool.Models;

    /// <summary>
    /// HTTP request headers data context interface.
    /// </summary>
    internal interface IHttpHeadersDataContext
    {
        /// <summary>
        /// Returns an enumerable of headers stored in a context.
        /// </summary>
        /// <returns>An enumerable of headers.</returns>
        IEnumerable<HttpHeader> Enumerate();

        /// <summary>
        /// Adds the header to a context.
        /// </summary>
        /// <param name="header">Header data.</param>
        void Add(HttpHeader header);

        /// <summary>
        /// Removes a range of headers from a context.
        /// </summary>
        /// <param name="headers">Headers to be removed.</param>
        void RemoveRange(IEnumerable<HttpHeader> headers);
    }

    /// <summary>
    /// Generic HTTP request headers data context interface with a specific underlying data source type.
    /// </summary>
    /// <typeparam name="TSource">Context underlying data source type.</typeparam>
    internal interface IHttpHeadersDataContext<in TSource> : IHttpHeadersDataContext, IInitializableDataContext<TSource>
        where TSource : class
    {
    }
}

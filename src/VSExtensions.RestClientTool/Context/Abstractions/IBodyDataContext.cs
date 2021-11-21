namespace VSExtensions.RestClientTool.Context.Abstractions
{
    using System.Net.Http;

    /// <summary>
    /// Request body data context interface.
    /// </summary>
    internal interface IBodyDataContext
    {
        /// <summary>
        /// Gets a value indicating whether there is content in a body.
        /// </summary>
        bool HasContent { get; }

        /// <summary>
        /// Returns an <see cref="HttpContent"/> instance created from content data stored in a context.
        /// </summary>
        /// <returns>An <see cref="HttpContent"/> instance.</returns>
        HttpContent GetHttpContent();
    }

    /// <summary>
    /// Generic request body data context with a specific underlying data source type.
    /// </summary>
    /// <typeparam name="TSource">Context underlying data source type.</typeparam>
    internal interface IBodyDataContext<in TSource> : IBodyDataContext, IInitializableDataContext<TSource>
        where TSource : class
    {
    }
}

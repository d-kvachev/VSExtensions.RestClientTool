namespace VSExtensions.RestClientTool.Context.Abstractions
{
    /// <summary>
    /// Rest client tool data context interface.
    /// </summary>
    internal interface IRestClientToolDataContext
    {
        /// <summary>
        /// Gets the data context of the request.
        /// </summary>
        IRequestDataContext Request { get; }

        /// <summary>
        /// Gets the data context of the response.
        /// </summary>
        IResponseDataContext Response { get; }
    }

    /// <summary>
    /// Generic rest client tool data context interface with a specific underlying data source type.
    /// </summary>
    /// <typeparam name="TSource">Context underlying data source type.</typeparam>
    internal interface IRestClientToolDataContext<in TSource> : IRestClientToolDataContext, IInitializableDataContext<TSource>
        where TSource : class
    {
    }
}

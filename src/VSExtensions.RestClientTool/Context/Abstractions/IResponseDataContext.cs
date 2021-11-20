namespace VSExtensions.RestClientTool.Context.Abstractions
{
    using VSExtensions.RestClientTool.Models;

    /// <summary>
    /// Response data context interface.
    /// </summary>
    internal interface IResponseDataContext
    {
        /// <summary>
        /// Sets the response data in context.
        /// </summary>
        /// <param name="data">Response data.</param>
        void SetData(ResponseData data);
    }

    /// <summary>
    /// Generic response data context interface with a specific underlying data source type.
    /// </summary>
    /// <typeparam name="TSource">Context underlying data source type.</typeparam>
    internal interface IResponseDataContext<in TSource> : IResponseDataContext, IInitializableDataContext<TSource>
        where TSource : class
    {
    }
}

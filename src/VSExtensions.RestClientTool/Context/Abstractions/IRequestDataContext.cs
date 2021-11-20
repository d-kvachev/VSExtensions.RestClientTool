namespace VSExtensions.RestClientTool.Context.Abstractions
{
    using VSExtensions.RestClientTool.Models;

    /// <summary>
    /// Request data context interface.
    /// </summary>
    internal interface IRequestDataContext
    {
        /// <summary>
        /// Returns request settings.
        /// </summary>
        /// <returns>Request settings.</returns>
        RequestSettings GetSettings();
    }

    /// <summary>
    /// Generic request data context interface with a specific underlying data source type.
    /// </summary>
    /// <typeparam name="TSource">Context underlying data source type.</typeparam>
    internal interface IRequestDataContext<in TSource> : IRequestDataContext, IInitializableDataContext<TSource>
        where TSource : class
    {
    }
}

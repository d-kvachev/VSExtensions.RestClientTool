namespace VSExtensions.RestClientTool.Context.Abstractions
{
    /// <summary>
    /// Provides operations for data context initialization.
    /// </summary>
    /// <typeparam name="TSource">Context underlying data source type.</typeparam>
    internal interface IInitializableDataContext<in TSource>
        where TSource : class
    {
        /// <summary>
        /// Initializes data context.
        /// </summary>
        /// <param name="dataSource">Underlying data source of context.</param>
        void Initialize(TSource dataSource);
    }
}

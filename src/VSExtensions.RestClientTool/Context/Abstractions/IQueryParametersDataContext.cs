namespace VSExtensions.RestClientTool.Context.Abstractions
{
    using System.Collections.Generic;

    using VSExtensions.RestClientTool.Models.Request;

    /// <summary>
    /// Request query parameters data context interface.
    /// </summary>
    internal interface IQueryParametersDataContext
    {
        /// <summary>
        /// Returns an enumerable of parameters stored in a context.
        /// </summary>
        /// <returns>An enumerable of query parameters.</returns>
        IEnumerable<QueryParameter> Enumerate();

        /// <summary>
        /// Adds the query parameter to a context.
        /// </summary>
        /// <param name="parameter">Query parameter data.</param>
        void Add(QueryParameter parameter);

        /// <summary>
        /// Removes a range of query parameters from a context.
        /// </summary>
        /// <param name="parameters">Query parameters to be removed.</param>
        void RemoveRange(IEnumerable<QueryParameter> parameters);
    }

    /// <summary>
    /// Generic request query parameters data context interface with a specific underlying data source type.
    /// </summary>
    /// <typeparam name="TSource">Context underlying data source type.</typeparam>
    internal interface IQueryParametersDataContext<in TSource> : IQueryParametersDataContext, IInitializableDataContext<TSource>
        where TSource : class
    {
    }
}

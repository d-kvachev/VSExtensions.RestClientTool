namespace VSExtensions.RestClientTool.Models.Request
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// HTTP request type.
    /// </summary>
    internal enum RequestType
    {
        /// <summary>
        /// HTTP GET.
        /// </summary>
        Get
    }

    /// <summary>
    /// Provides available request types.
    /// </summary>
    internal static class RequestTypesProvider
    {
        /// <summary>
        /// Available request types.
        /// </summary>
        public static IReadOnlyCollection<RequestType> _types;

        /// <summary>
        /// Returns all available request types.
        /// </summary>
        /// <returns>Available request types.</returns>
        public static IReadOnlyCollection<RequestType> Get()
        {
            if (_types == null)
                _types = Enum.GetValues(typeof(RequestType)).Cast<RequestType>().ToList();

            return _types;
        }
    }
}

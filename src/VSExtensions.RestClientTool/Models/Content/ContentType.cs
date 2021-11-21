namespace VSExtensions.RestClientTool.Models.Content
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Content type.
    /// </summary>
    internal enum ContentType
    {
        /// <summary>
        /// Empty content.
        /// </summary>
        None,

        /// <summary>
        /// A JSON content.
        /// </summary>
        Json
    }

    /// <summary>
    /// Provides available content types.
    /// </summary>
    internal static class ContentTypesProvider
    {
        /// <summary>
        /// Available content types.
        /// </summary>
        public static IReadOnlyCollection<ContentType> _types;

        /// <summary>
        /// Returns all available content types.
        /// </summary>
        /// <returns>Available content types.</returns>
        public static IReadOnlyCollection<ContentType> Get()
        {
            if (_types == null)
                _types = Enum.GetValues(typeof(ContentType)).Cast<ContentType>().ToList();

            return _types;
        }
    }
}

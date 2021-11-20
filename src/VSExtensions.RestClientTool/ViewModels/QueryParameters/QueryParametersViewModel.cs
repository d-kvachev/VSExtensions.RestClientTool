namespace VSExtensions.RestClientTool.ViewModels.QueryParameters
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using VSExtensions.RestClientTool.Commands;
    using VSExtensions.RestClientTool.Context.Abstractions;

    /// <summary>
    /// Contains logic for query parameters customization.
    /// </summary>
    internal class QueryParametersViewModel : ViewModelBase
    {
        /// <summary>
        /// Query parameters data context.
        /// </summary>
        private IQueryParametersDataContext _context;

        /// <summary>
        /// Gets the collection of query parameters.
        /// </summary>
        public ObservableCollection<QueryParameterViewModel> Parameters { get; } = new ObservableCollection<QueryParameterViewModel>();

        /// <summary>
        /// Gets a command that adds new query parameter to the collection.
        /// </summary>
        public ICommand AddCommand => CommandFactory.AddQueryParameter(_context);

        /// <summary>
        /// Gets a command that removes all disabled query parameters from the collection.
        /// </summary>
        public ICommand RemoveDisabledCommand => CommandFactory.RemoveDisabledParameters(_context);

        /// <summary>
        /// Sets query parameters data context.
        /// </summary>
        /// <param name="context">Query parameters data context.</param>
        public void SetContext(IQueryParametersDataContext context) => _context = context;
    }
}

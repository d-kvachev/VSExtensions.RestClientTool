namespace VSExtensions.RestClientTool.Context
{
    using System.Collections.Generic;
    using System.Linq;

    using VSExtensions.RestClientTool.Context.Abstractions;
    using VSExtensions.RestClientTool.Models;
    using VSExtensions.RestClientTool.ViewModels.QueryParameters;

    /// <summary>
    /// A query parameters data context that uses a view model as an underlying data source.
    /// </summary>
    internal class QueryParametersViewModelDataContext : IQueryParametersDataContext<QueryParametersViewModel>
    {
        /// <summary>
        /// The query parameters view model that is used as the data source.
        /// </summary>
        private QueryParametersViewModel _viewModel;

        /// <inheritdoc />
        public void Initialize(QueryParametersViewModel dataSource) => _viewModel = dataSource;

        /// <inheritdoc />
        public void Add(QueryParameter parameter)
        {
            var parameterVm = ToViewModel(parameter);
            _viewModel.Parameters.Add(parameterVm);
        }

        /// <inheritdoc />
        public IEnumerable<QueryParameter> Enumerate() => _viewModel.Parameters.Select(ToQueryParameter).ToList();

        /// <inheritdoc />
        public void RemoveRange(IEnumerable<QueryParameter> parameters)
        {
            var parametersToRemove = _viewModel.Parameters
                .Where(pvm => parameters.Any(p => pvm.Enabled == p.Enabled && pvm.Key == p.Key))
                .ToList();

            foreach (var toRemove in parametersToRemove)
                _viewModel.Parameters.Remove(toRemove);
        }

        /// <summary>
        /// Converts a <see cref="QueryParameter"/> object to a <see cref="QueryParameterViewModel"/> instance.
        /// </summary>
        /// <param name="parameter">A <see cref="QueryParameter"/> object.</param>
        /// <returns>A <see cref="QueryParameterViewModel"/> instance.</returns>
        public QueryParameterViewModel ToViewModel(QueryParameter parameter)
        {
            return new QueryParameterViewModel
            { 
                Enabled = parameter.Enabled,
                Key = parameter.Key,
                Value = parameter.Value
            };
        }

        /// <summary>
        /// Converts a <see cref="QueryParameterViewModel"/> object to a <see cref="QueryParameter"/> instance.
        /// </summary>
        /// <param name="viewModel">A <see cref="QueryParameterViewModel"/> object.</param>
        /// <returns>A <see cref="QueryParameter"/> instance.</returns>
        public QueryParameter ToQueryParameter(QueryParameterViewModel viewModel) =>
            new QueryParameter(viewModel.Enabled, viewModel.Key, viewModel.Value);
    }
}

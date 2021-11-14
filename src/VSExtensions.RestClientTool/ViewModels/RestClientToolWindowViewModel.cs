namespace VSExtensions.RestClientTool.ViewModels
{
    using System.Windows.Input;

    using VSExtensions.RestClientTool.Commands;

    /// <summary>
    /// The main user control view model.
    /// </summary>
    internal class RestClientToolWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestClientToolWindowViewModel"/> class.
        /// </summary>
        public RestClientToolWindowViewModel()
        {
            RequestViewModel = new RequestViewModel();
            ResponseViewModel = new ResponseViewModel();
        }

        /// <summary>
        /// Gets a request view model containing logic for request customization.
        /// </summary>
        public RequestViewModel RequestViewModel { get; }

        /// <summary>
        /// Gets a response view model, containing logic for response processing.
        /// </summary>
        public ResponseViewModel ResponseViewModel { get; }

        /// <summary>
        /// Gets a command that sends a request to an endpoint.
        /// </summary>
        public ICommand SendRequestCommand => CommandFactory.SendRequest(RequestViewModel, ResponseViewModel);
    }
}

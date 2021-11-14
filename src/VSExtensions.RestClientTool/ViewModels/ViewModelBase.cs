namespace VSExtensions.RestClientTool.ViewModels
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Abstract class containing common view model logic.
    /// </summary>
    internal abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Safely invokes the <see cref="PropertyChanged"/> event.
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = default) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

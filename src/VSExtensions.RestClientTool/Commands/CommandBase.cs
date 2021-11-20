namespace VSExtensions.RestClientTool.Commands
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// A command base class.
    /// </summary>
    internal abstract class CommandBase : ICommand
    {
        /// <inheritdoc />
        public event EventHandler CanExecuteChanged;

        /// <inheritdoc />
        public abstract bool CanExecute(object parameter);

        /// <inheritdoc />
        public abstract void Execute(object parameter);

        /// <summary>
        /// Safely invokes the <see cref="CanExecuteChanged"/> event.
        /// </summary>
        protected void OnCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}

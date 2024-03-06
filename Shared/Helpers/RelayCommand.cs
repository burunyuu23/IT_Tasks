using System.Windows.Input;

namespace IT_Tasks;

public class RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
    : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter) => parameter != null && (canExecute == null || canExecute(parameter));

    public void Execute(object? parameter)
    {
        if (parameter != null) execute(parameter);
    }
}
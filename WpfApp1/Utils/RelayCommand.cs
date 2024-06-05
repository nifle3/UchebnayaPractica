using System.Windows.Input;

namespace WpfApp1.Utils;

public class RelayCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<object?, bool>? _canExecute;
    
    public RelayCommand(Action execute, Func<object?, bool>? canExecute = null)
    {
        this._execute = execute;
        this._canExecute = canExecute;
    }
 
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    
    public bool CanExecute(object? parameter)
    {
        return this._canExecute == null || this._canExecute(parameter);
    }
 
    public void Execute(object? parameter)
    {
        this._execute();
    }
}
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel;

public abstract class BaseCrud<T> : BaseDb
{
    protected const string UpdateSuccessMessage = "Запись успешно обновлена!";
    protected const string AddSuccessMessage = "Запись успешно добавлена!";
    protected const string DeleteSuccessMessage = "Запись успешно добавлена!";
    
    protected BaseCrud(IAlert notifier) : base(notifier)
    {
        AddCommand = new AsyncRelayCommand(Add);
        DeleteCommand = new AsyncRelayCommand<T>(Delete);
        UpdateCommand = new AsyncRelayCommand<T>(Update);
    }


    public ICommand AddCommand { private set; get; }
    
    public ICommand DeleteCommand { private set; get; }
    
    public ICommand UpdateCommand { private set; get; }

    
    protected abstract Task Add();
    
    protected abstract Task Delete(T? entity);
    
    protected abstract Task Update(T? entity);
}
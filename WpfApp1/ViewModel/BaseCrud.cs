using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using WpfApp1.ViewModel.Service;
using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel;

public abstract class BaseCrud<T> : BaseAlert
{
    private readonly IService<T> _service;

    protected const string DbErrorMessage = "Ошибка в базе данных";
    protected const string UpdateSuccessMessage = "Запись успешно обновлена!";
    protected const string AddSuccessMessage = "Запись успешно добавлена!";
    protected const string DeleteSuccessMessage = "Запись успешно добавлена!";

    protected event Predicate<T>? CanUpdateEvent;
    protected event Action<T>? DeleteEvent; 

    protected BaseCrud(IService<T> service, IAlert notifier) : base(notifier)
    {
        _service = service;
        
        AddCommand = new AsyncRelayCommand(Add);
        DeleteCommand = new AsyncRelayCommand<T>(Delete);
        UpdateCommand = new AsyncRelayCommand<T>(Update);
    }
    
    public ICommand AddCommand { private set; get; }
    
    public ICommand DeleteCommand { private set; get; }
    
    public ICommand UpdateCommand { private set; get; }

    
    protected abstract Task Add();

    private async Task Delete(T? entity)
    {
        if (entity is null) return;

        var result = await _service.RemoveAsync(entity);
        if (!result)
        {
            Notifier.Alert(DbErrorMessage);
            return;
        }
        
        DeleteEvent?.Invoke(entity);
        Notifier.Alert(DeleteSuccessMessage);
    }

    private async Task Update(T? entity)
    {
        if (entity is null) return;
        
        var isOk = CanUpdateEvent?.Invoke(entity);
        if (isOk.HasValue && !isOk.Value) return;

        var result = await _service.UpdateAsync(entity);
        if (!result)
        {
            Notifier.Alert(DbErrorMessage);
            return;
        }
        
        Notifier.Alert(UpdateSuccessMessage);
    }
}
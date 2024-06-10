using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp1.ViewModel.Message;
using WpfApp1.ViewModel.Service;

namespace WpfApp1.ViewModel;

public abstract class BaseCrud<T> : Base
{
    private readonly ICrudService<T> _crudService;

    private const string DbErrorMessage = "Ошибка в базе данных";
    private const string UpdateSuccessMessage = "Запись успешно обновлена!";
    private const string AddSuccessMessage = "Запись успешно добавлена!";
    private const string DeleteSuccessMessage = "Запись успешно добавлена!";

    protected event Predicate<T>? CanModifyEvent;
    protected event Action<T>? DeleteEvent;
    protected event Action<T>? AddEvent;

    protected BaseCrud(ICrudService<T> crudService)
    {
        _crudService = crudService;
        
        AddCommand = new AsyncRelayCommand(Add);
        DeleteCommand = new AsyncRelayCommand<T>(Delete);
        UpdateCommand = new AsyncRelayCommand<T>(Update);
    }
    
    public ICommand AddCommand { private set; get; }
    
    public ICommand DeleteCommand { private set; get; }
    
    public ICommand UpdateCommand { private set; get; }

    protected abstract T GetEntity();
    
    private async Task Add()
    {
        var result = GetEntity();
        
        var isOk = CanModifyEvent?.Invoke(result);
        if (isOk.HasValue && !isOk.Value) return;
        
        var entity = await _crudService.AddAsync(result);
        if (entity is null)
        {
            WeakReferenceMessenger.Default.Send(new AlertMessage(DbErrorMessage, ErrorCaptionsMessage));
            return;
        }
        
        WeakReferenceMessenger.Default.Send(new AlertMessage(AddSuccessMessage, SuccessCaptionsMessage));
        AddEvent?.Invoke(entity);
    }

    private async Task Delete(T? entity)
    {
        if (entity is null) return;

        var result = await _crudService.RemoveAsync(entity);
        if (!result)
        {
            WeakReferenceMessenger.Default.Send(new AlertMessage(DbErrorMessage, ErrorCaptionsMessage));
            return;
        }
        
        DeleteEvent?.Invoke(entity);
        WeakReferenceMessenger.Default.Send(new AlertMessage(DeleteSuccessMessage, SuccessCaptionsMessage));
    }

    private async Task Update(T? entity)
    {
        if (entity is null) return;
        
        var isOk = CanModifyEvent?.Invoke(entity);
        if (isOk.HasValue && !isOk.Value) return;

        var result = await _crudService.UpdateAsync(entity);
        if (!result)
        {
            WeakReferenceMessenger.Default.Send(new AlertMessage(DbErrorMessage, ErrorCaptionsMessage));
            return;
        }
        
        WeakReferenceMessenger.Default.Send(new AlertMessage(UpdateSuccessMessage, SuccessCaptionsMessage));
    }
}
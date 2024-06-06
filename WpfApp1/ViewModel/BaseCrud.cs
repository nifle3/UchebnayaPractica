using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using WpfApp1.Model;
using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel;

public abstract class BaseCrud<T> : BaseDb
{
    protected BaseCrud(IAlert alert) : base(alert)
    {
        AddCommand = new AsyncRelayCommand(Add);
        DeleteCommand = new AsyncRelayCommand<T>(Delete);
        UpdateCommand = new RelayCommand(Update);
    }

    public ICommand AddCommand { private set; get; }
    
    public ICommand DeleteCommand { private set; get; }
    
    public ICommand UpdateCommand { private set; get; }
    
    protected abstract Task Add();
    
    protected abstract Task Delete(T? entity);
    
    protected abstract void Update();
}
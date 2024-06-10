using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using WpfApp1.ViewModel.Service;

namespace WpfApp1.ViewModel;

public abstract class BaseSearch<T> : BaseCrud<T>
{
    protected BaseSearch(ICrudService<T> crudService) : base(crudService)
    {
        SearchCommand = new RelayCommand(Search);
        RefreshCommand = new RelayCommand(Refresh);
    }
    
    public ICommand SearchCommand { private set; get; }

    public ICommand RefreshCommand { private set; get; }
    
    protected abstract void Search();
    
    protected abstract void Refresh();
}
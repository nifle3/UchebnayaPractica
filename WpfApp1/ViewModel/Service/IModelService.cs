using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel.Service;

public interface IModelService<T>
{
    public ObservableCollection<T> GetAll();

    public Task<T?> AddAsync(T entity);
}
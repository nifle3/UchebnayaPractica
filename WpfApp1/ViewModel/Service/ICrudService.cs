using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel.Service;

public interface ICrudService<T>
{
    public Task<T?> AddAsync(T entity);
    
    public Task<bool> UpdateAsync(T entity);

    public Task<bool> RemoveAsync(T entity);
}
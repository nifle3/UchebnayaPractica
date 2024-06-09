using System.Collections.ObjectModel;

namespace WpfApp1.ViewModel.Service;

public interface IService<in T>
{
    public Task<bool> UpdateAsync(T entity);

    public Task<bool> RemoveAsync(T entity);
}
using WpfApp1.Model;
using WpfApp1.ViewModel.Service;

namespace WpfApp1.Service;

public sealed class CrudService<T> : ICrudService<T> where T : class
{
    public async Task<T?> AddAsync(T entity)
    {
        try
        {
            var result = await RealtorsStoreContext.Instance.AddAsync(entity);
            await RealtorsStoreContext.Instance.SaveChangesAsync();

            return result.Entity as T;
        }
        catch
        {
            return default(T?);
        }
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        try
        {
            RealtorsStoreContext.Instance.Update(entity);
            await RealtorsStoreContext.Instance.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> RemoveAsync(T entity)
    {
        try
        {
            RealtorsStoreContext.Instance.Remove(entity);
            await RealtorsStoreContext.Instance.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }
}
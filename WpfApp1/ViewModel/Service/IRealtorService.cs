using Microsoft.EntityFrameworkCore;
using WpfApp1.Model;

namespace WpfApp1.ViewModel.Service;

public interface IRealtorService : IModelService<Realtor>
{
    public DbSet<Realtor> GetForSearch();
}
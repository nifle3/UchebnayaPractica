using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using WpfApp1.Model;

namespace WpfApp1.ViewModel.Service;

public interface IClientService
{
    public ObservableCollection<Client> GetAll();

    public DbSet<Client> GetForSearch();
}
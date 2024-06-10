using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using WpfApp1.Model;
using WpfApp1.ViewModel.Service;

namespace WpfApp1.Service;

public sealed class ClientService : IClientService
{
    public ObservableCollection<Client> GetAll()
    {
        return new ObservableCollection<Client>(GetForSearch());
    }

    public DbSet<Client> GetForSearch()
    {
        return RealtorsStoreContext.Instance.Clients;
    }
}
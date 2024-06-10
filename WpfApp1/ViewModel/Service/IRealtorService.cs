using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using WpfApp1.Model;

namespace WpfApp1.ViewModel.Service;

public interface IRealtorService
{
    public ObservableCollection<Realtor> GetAll();

    public Task<ObservableCollection<Realtor>> GetSearch(string name, string lastName, string middleName);
}
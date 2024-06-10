using System.Collections.ObjectModel;
using WpfApp1.Model;

namespace WpfApp1.ViewModel.Service;

public interface IClientService
{
    public ObservableCollection<Client> GetAll();

    public ObservableCollection<Client> GetSearch(string name, string lastName, string middleName);

}
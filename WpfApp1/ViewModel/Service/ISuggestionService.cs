using System.Collections.ObjectModel;
using WpfApp1.Model;

namespace WpfApp1.ViewModel.Service;

public interface ISuggestionService
{
    public ObservableCollection<Suggestion> GetAll();

    public List<Client> GetAllClients();

    public List<Estate> GetAllEstates();

    public List<Realtor> GetAllRealtors();
}
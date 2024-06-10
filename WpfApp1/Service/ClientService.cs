using System.Collections.ObjectModel;
using WpfApp1.Model;
using WpfApp1.Utils.Algorithm;
using WpfApp1.ViewModel.Service;

namespace WpfApp1.Service;

public sealed class ClientService : IClientService
{
    public ObservableCollection<Client> GetAll() =>
        new (RealtorsStoreContext.Instance.Clients);

    public async Task<ObservableCollection<Client>> GetSearch(string name, string lastName, 
        string middleName)
    {
        var task = Task.Run(() =>
        {
            const int minLevenstein = 3;
            IQueryable<Client> query = RealtorsStoreContext.Instance.Clients;


            if (!string.IsNullOrWhiteSpace(name))
                query = query
                    .Where(q => q.FirstName != null &&
                                Search.LevenshteinDistance(q.FirstName, name) <= minLevenstein);

            if (!string.IsNullOrWhiteSpace(lastName))
                query = query
                    .Where(q => q.LastName != null &&
                                Search.LevenshteinDistance(q.LastName, lastName) <= minLevenstein);

            if (!string.IsNullOrWhiteSpace(middleName))
                query = query.Where(q =>
                    q.MiddleName != null && Search.LevenshteinDistance(q.MiddleName, middleName) <=
                    minLevenstein);

            return new ObservableCollection<Client>(query);
        });

        var result = await task;
        return result;
    }
}
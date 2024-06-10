using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using WpfApp1.Model;
using WpfApp1.Utils.Algorithm;
using WpfApp1.ViewModel.Service;

namespace WpfApp1.Service;

public sealed class RealtorService : IRealtorService
{
    public ObservableCollection<Realtor> GetAll() =>
        new(RealtorsStoreContext.Instance.Realtors);

    public async Task<ObservableCollection<Realtor>> GetSearch(string name, string lastName, string middleName)
    {
        var task = Task.Run(() =>
        {
            const int minLevenstein = 3;
            IQueryable<Realtor> query = RealtorsStoreContext.Instance.Realtors;
        

            if (!string.IsNullOrWhiteSpace(name))
                query = query
                    .Where(q => Search.LevenshteinDistance(q.FirstName, name) <= minLevenstein);

            if (!string.IsNullOrWhiteSpace(lastName))
                query = query
                    .Where(q => Search.LevenshteinDistance(q.LastName, lastName) <= minLevenstein);

            if (!string.IsNullOrWhiteSpace(middleName))
                query = query.Where(q =>
                    Search.LevenshteinDistance(q.MiddleName, middleName) <= minLevenstein);
        
            return new ObservableCollection<Realtor>(query);
        });
        
        var result = await task;
        return result;
    }
}
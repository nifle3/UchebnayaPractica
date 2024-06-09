using System.Collections.ObjectModel;
using WpfApp1.Model;
using WpfApp1.ViewModel.Service;
using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel;

public sealed class RealtorViewModel : BaseSearch<Realtor>
{
    private readonly IRealtorService _service;
    
    private string _name = "";
    private string _lastName = "";
    private string _middleName = "";
    private int _commision;
    
    private string _searchName = "";
    private string _searchLastName = "";
    private string _searchMiddleName = "";

    public RealtorViewModel(IRealtorService service, IAlert notifier) : base(notifier)
    {
        _service = service;

        Realtors = _service.GetAll();
    }
    
    public ObservableCollection<Realtor> Realtors { private set; get; }

    public string Name
    {
        set => SetField(ref _name, value);
        get => _name;
    }

    public string LastName
    {
        set => SetField(ref _lastName, value);
        get => _lastName;
    }

    public string MiddleName
    {
        set => SetField(ref _middleName, value);
        get => _middleName;
    }

    public int Commision
    {
        set => SetField(ref _commision, value);
        get => _commision;
    }

    public string SearchName
    {
        set => SetField(ref _searchName, value);
        get => _searchName;
    }
    
    public string SearchMiddleName
    {
        set => SetField(ref _searchMiddleName, value);
        get => _searchMiddleName;
    }

    public string SearchLastName
    {
        set => SetField(ref _searchLastName, value);
        get => _searchLastName; 
    }

    protected override async Task Search()
    {
        var task = Task.Run(() =>
        {
            const int minLevenstein = 3;
            IQueryable<Realtor> query = _service.GetForSearch();
        

            if (!string.IsNullOrWhiteSpace(SearchName))
                query = query
                    .Where(q => RealtorsStoreContext.LevenshteinDistance(q.FirstName, SearchName) <= minLevenstein);

            if (!string.IsNullOrWhiteSpace(SearchLastName))
                query = query
                    .Where(q => RealtorsStoreContext.LevenshteinDistance(q.LastName, SearchLastName) <= minLevenstein);

            if (!string.IsNullOrWhiteSpace(SearchMiddleName))
                query = query.Where(q =>
                    RealtorsStoreContext.LevenshteinDistance(q.MiddleName, SearchMiddleName) <= minLevenstein);
        
            Realtors = new ObservableCollection<Realtor>(query);
        });
        
        await task;     
    }

    protected override async Task Add()
    {
        var realtor = new Realtor()
        {
            Comission = _commision,
            FirstName = Name,
            LastName = LastName,
            MiddleName = MiddleName,
        };

        var result = await _service.AddAsync(realtor);
        if (result is null)
        {
            Notifier.Alert(DbErrorMessage);
            return;
        }

        Realtors.Add(result);
        Notifier.Alert(AddSuccessMessage);
    }

    protected override async Task Delete(Realtor? realtor)
    {
        if (realtor is null) return;

        var isOk = await _service.RemoveAsync(realtor);
        if (!isOk)
        {
            Notifier.Alert(DbErrorMessage);
            return;
        }

        Realtors.Remove(realtor);
        Notifier.Alert(DeleteSuccessMessage);
    }

    protected override async Task Update(Realtor? entity)
    {
        if (entity is null) return;
        
        if (string.IsNullOrWhiteSpace(entity.FirstName) || string.IsNullOrWhiteSpace(entity.MiddleName) ||
            string.IsNullOrWhiteSpace(entity.LastName))
        {
            Notifier.Alert("Фамилия, имя и отчество должны быть заполнены");
            return;
        }

        var isOk = await _service.UpdateAsync(entity);
        if (!isOk)
        {
            Notifier.Alert(DbErrorMessage);
            return;
        }
        
        Notifier.Alert(UpdateSuccessMessage);
        
    }
}
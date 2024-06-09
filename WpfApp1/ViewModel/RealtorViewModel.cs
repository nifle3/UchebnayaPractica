using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp1.Model;
using WpfApp1.ViewModel.Service;

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

    public RealtorViewModel(IRealtorService service, ICrudService<Realtor> crudService) : base(crudService)
    {
        _service = service;

        CanUpdateEvent += CanUpdate;
        DeleteEvent += Delete;
        AddEvent += Add;

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
    
    protected override Realtor GetEntity() =>
        new Realtor()
        {
            Comission = Commision,
            FirstName = Name,
            LastName = LastName,
            MiddleName = MiddleName,
        };

    private void Add(Realtor entity) =>
        Realtors.Add(entity);
    
    private void Delete(Realtor entity) =>
        Realtors.Remove(entity);

    private bool CanUpdate(Realtor entity)
    {
        if (!string.IsNullOrWhiteSpace(entity.FirstName) && !string.IsNullOrWhiteSpace(entity.MiddleName) &&
            !string.IsNullOrWhiteSpace(entity.LastName)) return true;
        
        WeakReferenceMessenger.Default.Send("Фамилия, имя и отчество должны быть заполнены");
        return false;
    }
}
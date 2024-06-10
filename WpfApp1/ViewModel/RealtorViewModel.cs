using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp1.Message;
using WpfApp1.Model;
using WpfApp1.ViewModel.Service;

namespace WpfApp1.ViewModel;

public sealed class RealtorViewModel : BaseSearch<Realtor>
{
    private readonly IRealtorService _service;

    private Realtor? _selectedRealtor;
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

        CanModifyEvent += CanModify;
        DeleteEvent += Delete;
        AddEvent += Add;

        Realtors = _service.GetAll();
    }

    public Realtor? SelectedRealtor
    {
        set => SetProperty(ref _selectedRealtor, value);
        get => _selectedRealtor;
    }
    
    public ObservableCollection<Realtor> Realtors { private set; get; }

    public string Name
    {
        set => SetProperty(ref _name, value);
        get => _name;
    }

    public string LastName
    {
        set => SetProperty(ref _lastName, value);
        get => _lastName;
    }

    public string MiddleName
    {
        set => SetProperty(ref _middleName, value);
        get => _middleName;
    }

    public int Commision
    {
        set => SetProperty(ref _commision, value);
        get => _commision;
    }

    public string SearchName
    {
        set => SetProperty(ref _searchName, value);
        get => _searchName;
    }
    
    public string SearchMiddleName
    {
        set => SetProperty(ref _searchMiddleName, value);
        get => _searchMiddleName;
    }

    public string SearchLastName
    {
        set => SetProperty(ref _searchLastName, value);
        get => _searchLastName; 
    }

    protected override async Task Search() =>
        Realtors = await _service.GetSearch(SearchName, SearchLastName, SearchMiddleName);

    protected override void Refresh()
    {
        SearchName = "";
        SearchLastName = "";
        SearchMiddleName = "";

        Realtors = _service.GetAll();
    }

    protected override Realtor GetEntity() =>
        new()
        {
            Comission = Commision == -1 ? null : Commision,
            FirstName = Name,
            LastName = LastName,
            MiddleName = MiddleName,
        };

    private void Add(Realtor realtor) =>
        Realtors.Add(realtor);
    
    private void Delete(Realtor realtor) =>
        Realtors.Remove(realtor);

    private static bool CanModify(Realtor realtor)
    {
        if (realtor.Comission is > 100 or < -1)
        {
            WeakReferenceMessenger.Default.Send(new AlertMessage("Коммиссия может быть от -1(будет null) до 100", ErrorCaptionsMessage));
            return false;
        }
        
        if (!string.IsNullOrWhiteSpace(realtor.FirstName) && !string.IsNullOrWhiteSpace(realtor.MiddleName) &&
            !string.IsNullOrWhiteSpace(realtor.LastName)) return true;
        
        WeakReferenceMessenger.Default.Send(new AlertMessage("Фамилия, имя и отчество должны быть заполнены", ErrorCaptionsMessage));
        return false;
    }
}
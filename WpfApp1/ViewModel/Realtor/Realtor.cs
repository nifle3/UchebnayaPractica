using System.Collections.ObjectModel;
using WpfApp1.Model;
using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel.Realtor;

public sealed class Realtor : BaseSearch<Model.Realtor>
{
    private string _name = "";
    private string _lastName = "";
    private string _middleName = "";
    private int _commision;
    
    private string _searchName = "";
    private string _searchLastName = "";
    private string _searchMiddleName = "";

    public Realtor(IAlert notifier) : base(notifier) =>
        Realtors = new ObservableCollection<Model.Realtor>(Context.Realtors);
       
    public ObservableCollection<Model.Realtor> Realtors { private set; get; }

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
            IQueryable<Model.Realtor> query = Context.Realtors;
        

            if (!string.IsNullOrWhiteSpace(SearchName))
                query = query
                    .Where(q => RealtorsStoreContext.LevenshteinDistance(q.FirstName, SearchName) <= minLevenstein);

            if (!string.IsNullOrWhiteSpace(SearchLastName))
                query = query
                    .Where(q => RealtorsStoreContext.LevenshteinDistance(q.LastName, SearchLastName) <= minLevenstein);

            if (!string.IsNullOrWhiteSpace(SearchMiddleName))
                query = query.Where(q =>
                    RealtorsStoreContext.LevenshteinDistance(q.MiddleName, SearchMiddleName) <= minLevenstein);
        
            Realtors = new ObservableCollection<Model.Realtor>(query);
        });
        
        await task;     
    }

    protected override async Task Add()
    {
        var realtor = new Model.Realtor()
        {
            Comission = _commision,
            FirstName = Name,
            LastName = LastName,
            MiddleName = MiddleName,
        };

        try
        {
            var insertedRealtor = await Context.Realtors.AddAsync(realtor);
            await Context.SaveChangesAsync();

            if (insertedRealtor.IsKeySet)
                Realtors.Add(insertedRealtor.Entity);
            else
                Realtors = new ObservableCollection<Model.Realtor>(Context.Realtors);
            
            Notifier.Alert(AddSuccessMessage);
        }
        catch
        {
            Notifier.Alert(DbErrorMessage);
        }
    }

    protected override async Task Delete(Model.Realtor? realtor)
    {
        if (realtor is null) return;

        try
        {
            Context.Realtors.Remove(realtor);
            await Context.SaveChangesAsync();

            Realtors.Remove(realtor);
            
            Notifier.Alert(DeleteSuccessMessage);
        }
        catch
        {
            Notifier.Alert(DbErrorMessage);
        }
    }

    protected override async Task Update(Model.Realtor? entity)
    {
        if (entity is null) return;
        
        if (string.IsNullOrWhiteSpace(entity.FirstName) || string.IsNullOrWhiteSpace(entity.MiddleName) ||
            string.IsNullOrWhiteSpace(entity.LastName))
        {
            Notifier.Alert("Фамилия, имя и отчество должны быть заполнены");
            return;
        }

        try
        {
            Context.Realtors.Update(entity);
            await Context.SaveChangesAsync();

            Notifier.Alert(UpdateSuccessMessage);
        }
        catch
        {
            Notifier.Alert(DbErrorMessage);
        }
    }
}
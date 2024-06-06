using System.Collections.ObjectModel;
using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel.Realtor;

public sealed class Realtor : BaseCrud<Model.Realtor>
{
    private string _name = "";
    private string _lastName = "";
    private string _middleName = "";
    private int _commision;

    public Realtor(IAlert alert) : base(alert) =>
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

    protected override async Task Add()
    {
        var reltor = new Model.Realtor()
        {
            Comission = _commision,
            FirstName = Name,
            LastName = LastName,
            MiddleName = MiddleName,
        };

        try
        {
            await Context.Realtors.AddAsync(reltor);
            await Context.SaveChangesAsync();
        }
        catch
        {
            Alert.Alert("Ошибка в базе данных");
        }
    }

    // TODO: сделать подтверждение
    protected override async Task Delete(Model.Realtor? realtor)
    {
        if (realtor is null) return;

        try
        {
            Context.Realtors.Remove(realtor);
            await Context.SaveChangesAsync();

            Realtors.Remove(realtor);
        }
        catch
        {
            Alert.Alert(DbErrorMessage);
        }
    }

    protected override void Update()
    {
        
    }
}
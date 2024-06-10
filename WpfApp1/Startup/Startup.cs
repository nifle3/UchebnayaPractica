using Autofac;
using WpfApp1.Model;
using WpfApp1.Service;
using WpfApp1.ViewModel;
using WpfApp1.ViewModel.Service;

namespace WpfApp1.Startup;

public class Startup
{
    private static readonly Lazy<Startup> Lazy = new(() =>
        new Startup());

    private Startup()
    {
    }

    public static Startup Instance =>
        Lazy.Value;
    
    public IContainer DiContainer { private set; get; }

    public void SettingDiContainer()
    {
        var builder = new ContainerBuilder();

        builder.RegisterType<ClientViewModel>().AsSelf();
        builder.RegisterType<CrudService<Client>>().As<ICrudService<Client>>();
        builder.RegisterType<ClientService>().As<IClientService>();

        DiContainer = builder.Build();
    }
}
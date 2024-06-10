using System.Windows.Controls;
using Autofac;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp1.Message;
using WpfApp1.ViewModel;

namespace WpfApp1.View.Pages;

public partial class ClientPage : Page
{
    private const string ClientPageName = "Клиенты";
    
    public ClientPage()
    {
        InitializeComponent();

        WeakReferenceMessenger.Default.Send(new RenameWindowMessage(ClientPageName));
        
        var startup = Startup.Startup.Instance;
        
        DataGrid.Items.Clear();
        DataContext = startup.DiContainer.Resolve<ClientViewModel>();
    }
}
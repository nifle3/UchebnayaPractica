using System.Windows.Controls;
using Autofac;
using WpfApp1.ViewModel;

namespace WpfApp1.View.Pages;

public partial class ClientPage : Page
{
    public ClientPage()
    {
        InitializeComponent();

        var startup = Startup.Startup.Instance;
        
        DataGrid.Items.Clear();
        DataContext = startup.DiContainer.Resolve<ClientViewModel>();
    }
}
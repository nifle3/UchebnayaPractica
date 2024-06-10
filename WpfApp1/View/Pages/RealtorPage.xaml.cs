using System.Windows.Controls;
using Autofac;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp1.Message;
using WpfApp1.ViewModel;

namespace WpfApp1.View.Pages;

public partial class RealtorPage : Page
{
    private const string RealtorPageName = "Риэлторы";
    
    public RealtorPage()
    {
        InitializeComponent();

        WeakReferenceMessenger.Default.Send(new RenameWindowMessage(RealtorPageName));
        
        DataGrid.Items.Clear();

        var startup = Startup.Startup.Instance;
        DataContext = startup.DiContainer.Resolve<RealtorViewModel>();
    }
}
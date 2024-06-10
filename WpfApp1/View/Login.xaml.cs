using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp1.Message;
using WpfApp1.ViewModel;

namespace WpfApp1.View;

public partial class Login : Window
{
    private const string Ok = "Ок";
    
    public Login()
    {
        InitializeComponent();
        DataContext = new LoginViewModel();
        
        WeakReferenceMessenger.Default.Register<AlertMessage>(this, (_, message) =>
        {
            MessageBox.Show(message.Text, message.Captions);
        });
        
        WeakReferenceMessenger.Default.Register<OpenWindowMessage>(this, (_, _) =>
        {
            var mainWindow = new Main(); 
            mainWindow.Show();
            
            this.Close();
        });
    }

    protected override void OnClosed(EventArgs e)
    {
        WeakReferenceMessenger.Default.UnregisterAll(this);
        
        base.OnClosed(e);
    }
}
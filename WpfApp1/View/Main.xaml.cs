using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp1.View.Pages;
using WpfApp1.ViewModel.Message;
using MessageBox = System.Windows.MessageBox;

namespace WpfApp1.View;

public partial class Main : Window
{
    public Main()
    {
        InitializeComponent();
        
        WeakReferenceMessenger.Default.Register<AlertMessage>(this, (_, msg) =>
        {
            MessageBox.Show(msg.Text, msg.Captions);
        });
    }

    protected override void OnClosed(EventArgs e)
    {
        WeakReferenceMessenger.Default.UnregisterAll(this);
        
        base.OnClosed(e);
    }

    private void ClientClick(object sender, RoutedEventArgs e)
    {
        Frame.RemoveBackEntry();
        Frame.Navigate(new ClientPage());
    }

    private void DealClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void RealtorClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void NeedClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void SuggestionClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void EstateClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}
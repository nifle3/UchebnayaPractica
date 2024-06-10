using System.Windows;
using WpfApp1.View.Pages;

namespace WpfApp1.View;

public partial class Main : Window
{
    public Main()
    {
        InitializeComponent();
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
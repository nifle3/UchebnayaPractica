using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp1.ViewModel.Message;

namespace WpfApp1.ViewModel;

public class LoginViewModel : Base
{
    private const string TrueEmail = "qwe@gmail.com";
    private const string TruePassword = "qwe";
    private const string InvalidEmailOrPassword = "Почта или пароль не правильные";

    private string _email = "";
    private string _password = "";

    public LoginViewModel() : base() =>
        AuthenticationCommand = new RelayCommand(Authentication);
    
    private string Email
    {
        set => SetField(ref _email, value);
        get => _email;
    }

    private string Password
    {
        set => SetField(ref _password, value);
        get => _password;
    }
    
    public ICommand AuthenticationCommand { private set; get; }

    private void Authentication()
    {
        if (_email != TrueEmail || _password != TruePassword)
        {
            WeakReferenceMessenger.Default.Send(new AlertMessage(InvalidEmailOrPassword));
            return;
        }

        WeakReferenceMessenger.Default.Send(new OpenWindowMessage());
    }
}
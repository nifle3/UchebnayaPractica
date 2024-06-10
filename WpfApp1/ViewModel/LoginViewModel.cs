using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WpfApp1.Message;

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
    
    public string Email
    {
        set => SetProperty(ref _email, value);
        get => _email;
    }

    public string Password
    {
        set => SetProperty(ref _password, value);
        get => _password;
    }
    
    public ICommand AuthenticationCommand { private set; get; }

    private void Authentication()
    {
        if (Email != TrueEmail || Password != TruePassword)
        {
            WeakReferenceMessenger.Default.Send(new AlertMessage(InvalidEmailOrPassword, ErrorCaptionsMessage));
            return;
        }
        
        WeakReferenceMessenger.Default.Send(new OpenWindowMessage());
    }
}
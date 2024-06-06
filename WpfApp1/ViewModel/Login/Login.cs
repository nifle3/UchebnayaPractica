using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel.Login;

public class Login : BaseAlert
{
    private const string TrueEmail = "qwe@gmail.com";
    private const string TruePassword = "qwe";
    private const string InvalidEmailOrPassword = "Почта или пароль не правильные";
    
    private readonly IWindowedMain _openerMain;
    
    private string _email = "";
    private string _password = "";

    public Login(IAlert alert, IWindowedMain main) : base(alert) =>
        (AuthenticationCommand, _openerMain)
            = (new RelayCommand(Authentication), main);
    
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
            Alert.Alert(InvalidEmailOrPassword);
            return;
        }
        
        _openerMain.OpenMain();
    }
}
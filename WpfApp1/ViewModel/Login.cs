using System.Windows.Input;
using WpfApp1.Utils;

namespace WpfApp1.ViewModel;

public interface IAlert
{
    public void Alert(string msg);
}

public interface IWindowedMain
{
    public void OpenMain();
}

public class Login : Base
{
    private const string TrueEmail = "qwe@gmail.com";
    private const string TruePassword = "qwe";
    private const string InvalidEmailOrPassword = "Почта или пароль не правильные";
    
    private readonly IAlert _alert;
    private readonly IWindowedMain _openerMain;
    
    private string _email = "";
    private string _password = "";

    public Login(IAlert alert, IWindowedMain main) =>
        (AuthenticationCommand, _alert, _openerMain)
            = (new RelayCommand(Authentication), alert, main);
    
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
            _alert.Alert(InvalidEmailOrPassword);
            return;
        }
        
        _openerMain.OpenMain();
    }
}
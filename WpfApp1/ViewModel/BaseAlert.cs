using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel;

public abstract class BaseAlert : Base
{
    protected IAlert Alert;

    protected BaseAlert(IAlert alert) =>
        Alert = alert;
}
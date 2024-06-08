using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel;

public abstract class BaseAlert : Base
{
    protected readonly IAlert Notifier;

    protected BaseAlert(IAlert notifier) =>
        Notifier = notifier;
}
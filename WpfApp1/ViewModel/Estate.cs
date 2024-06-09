using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel;

public abstract class Estate : BaseDb
{
    protected Estate(IAlert alert) : base(alert)
    {
    }
}
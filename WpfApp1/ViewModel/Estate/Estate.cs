using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel.Estate;

public abstract class Estate : BaseDb
{
    public Estate(IAlert alert) : base(alert)
    {
    }
}
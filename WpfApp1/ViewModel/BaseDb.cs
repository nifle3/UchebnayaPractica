using WpfApp1.Model;
using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel;

public abstract class BaseDb : BaseAlert
{
    protected const string DbErrorMessage = "Ошибка базы данных";
    
    protected RealtorsStoreContext Context;

    protected BaseDb(IAlert notifier) : base(notifier) =>
        Context = RealtorsStoreContext.Instance;
}
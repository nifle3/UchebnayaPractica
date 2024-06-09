using WpfApp1.ViewModel.Service;

namespace WpfApp1.ViewModel;

public abstract class EstateViewModel<T> : BaseCrud<T>
{
    protected EstateViewModel(ICrudService<T> crudService) : base(crudService)
    {
    }
}
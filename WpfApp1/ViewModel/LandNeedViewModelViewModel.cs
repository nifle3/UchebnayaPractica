using WpfApp1.Model;
using WpfApp1.ViewModel.Service;

namespace WpfApp1.ViewModel;

public sealed class LandNeedViewModelViewModel : NeedViewModel<LandsNeed>
{
    public LandNeedViewModelViewModel(ICrudService<LandsNeed> crudService) : base(crudService)
    {
    }

    protected override LandsNeed GetEntity()
    {
        throw new NotImplementedException();
    }
}
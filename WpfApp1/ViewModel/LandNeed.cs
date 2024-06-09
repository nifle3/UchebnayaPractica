using WpfApp1.Model;
using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel;

public sealed class LandNeed : Need<Model.LandsNeed>
{
    public LandNeed(IAlert alert) : base(alert)
    {
    }

    protected override async Task Add()
    {
        throw new NotImplementedException();
    }

    protected override async Task Delete(LandsNeed? entity)
    {
        if (entity is null) return;
        
    }

    protected override async Task Update(LandsNeed? entity)
    {
        if (entity is null) return;
    }
}
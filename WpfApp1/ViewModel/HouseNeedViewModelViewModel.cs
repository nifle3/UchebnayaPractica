﻿using WpfApp1.Model;
using WpfApp1.ViewModel.Service;

namespace WpfApp1.ViewModel;

public sealed class HouseNeedViewModelViewModel : NeedViewModel<HouseNeed>
{
    private double _minSquare = 0.0;
    private double _maxSquare = 0.0;
    private int _minRoomsCount = 0;
    private int _maxRoomsCount = 0;
    private int _minFloorsCount = 0;
    private int _maxFloorsCount = 0;
    
    public HouseNeedViewModelViewModel(ICrudService<HouseNeed> crudService) : base(crudService)
    {
    }

    public double MinSquare
    {
        set => SetProperty(ref _minSquare, value);
        get => _minSquare;
    }

    public double MaxSquare
    {
        set => SetProperty(ref _maxSquare, value);
        get => _maxSquare;
    }

    public int MinRoomsCount
    {
        set => SetProperty(ref _minRoomsCount, value);
        get => _minRoomsCount;
    }

    public int MaxRoomsCount
    {
        set => SetProperty(ref _maxRoomsCount, value);
        get => _maxRoomsCount;
    }

    public int MinFloorsCount
    {
        set => SetProperty(ref _minFloorsCount, value);
        get => _minFloorsCount;
    }

    public int MaxFloorsCount
    {
        set => SetProperty(ref _maxFloorsCount, value);
        get => _maxFloorsCount;
    }

    protected override HouseNeed GetEntity()
    {
        throw new NotImplementedException();
    }
}
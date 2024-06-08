﻿using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel;

public abstract class BaseSearch<T> : BaseCrud<T>
{
    protected BaseSearch(IAlert notifier) : base(notifier)
    {
        SearchCommand = new AsyncRelayCommand(Search);
    }
    
    public ICommand SearchCommand { private set; get; }

    protected abstract Task Search();
}
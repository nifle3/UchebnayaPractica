using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using WpfApp1.ViewModel.Utils;

namespace WpfApp1.ViewModel;

public abstract class Base : ObservableObject
{
    protected void SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return;
        
        field = value;
        OnPropertyChanged(propertyName);
    }
}
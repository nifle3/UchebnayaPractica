using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1.ViewModel;

public abstract class Base : ObservableObject
{
    protected const string ErrorCaptionsMessage = "Уведомление об ошибке";
    protected const string SuccessCaptionsMessage = "Уведомление об успехе";
    
    protected void SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return;
        
        field = value;
        OnPropertyChanged(propertyName);
    }
}
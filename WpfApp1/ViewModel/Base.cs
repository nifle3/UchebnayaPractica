using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfApp1.ViewModel;

public abstract class Base : ObservableValidator
{
    protected const string ErrorCaptionsMessage = "Уведомление об ошибке";
    protected const string SuccessCaptionsMessage = "Уведомление об успехе";
}
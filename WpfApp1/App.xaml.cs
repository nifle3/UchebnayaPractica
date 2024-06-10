using System.Windows;
using Autofac;

namespace WpfApp1;

public partial class App : Application
{
    public App()
    {
        var startup = WpfApp1.Startup.Startup.Instance;
        startup.SettingDiContainer();
    }    
}
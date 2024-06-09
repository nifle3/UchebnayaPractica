namespace WpfApp1.ViewModel.Message;

public sealed class AlertMessage
{
    public string Text { get; }

    public AlertMessage(string text) 
        => Text = text;

    public AlertMessage() =>
        Text = "";
}
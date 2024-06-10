namespace WpfApp1.ViewModel.Message;

public sealed class AlertMessage
{
    public AlertMessage(string text, string captions) 
        => (Text, Captions) = (text, captions);

    public AlertMessage() : this("", "") {}
    
    public string Text { get; }
    
    public string Captions { get; }
}
namespace WpfApp1.ViewModel.Messenge;

internal class StringMessage
{
    public string Text { get; }

    public StringMessage(string text) 
        => Text = text;

    public StringMessage() =>
        Text = "";
}
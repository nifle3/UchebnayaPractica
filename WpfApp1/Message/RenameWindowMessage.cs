namespace WpfApp1.Message;

public sealed class RenameWindowMessage
{
    public string Name { get; }

    public RenameWindowMessage(string name) =>
        Name = name;
    
    public RenameWindowMessage() : this("") {}
}
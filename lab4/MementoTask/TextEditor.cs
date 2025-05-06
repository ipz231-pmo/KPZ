namespace MementoTask;

class TextDocument
{
    public string Content { get; set; }
}


class DocumentMemento
{
    public string Content { get; }
    public DateTime Timestamp { get; }

    public DocumentMemento(string content)
    {
        Content = content;
        Timestamp = DateTime.Now;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"[Saved at {Timestamp}] Content: {Content}");
    }
}


class TextEditor
{
    private TextDocument _document = new TextDocument();
    private Stack<DocumentMemento> _history = new();
    private Queue<DocumentMemento> _revertedHistory = new();

    public void Write(string text)
    {
        Save();
        _document.Content += text;
    }

    public void Show()
    {
        Console.WriteLine("Current content: " + _document.Content);
    }

    public void Save()
    {
        _history.Push(new DocumentMemento(_document.Content));
        _revertedHistory.Clear();
    }

    public void Undo()
    {
        if (_history.Count > 0)
        {
            var memento = _history.Pop();
            _revertedHistory.Enqueue(memento);
            _document.Content = memento.Content;
            Console.WriteLine($"Undo to: {memento.Timestamp}");
        }
        else
        {
            Console.WriteLine("Nothing to undo.");
        }
    }
    public void Redo()
    {
        if (_revertedHistory.Count > 0)
        {
            var memento = _revertedHistory.Dequeue();
            _history.Push(memento);
            _document.Content = memento.Content;
            Console.WriteLine($"Redo to: {memento.Timestamp}");
        }
        else
        {
            Console.WriteLine("Nothing to redo.");
        }
    }

    public void ShowHistory()
    {
        Console.WriteLine("History:");
        foreach (var memento in _history)
        {
            memento.ShowInfo();
        }
    }
}
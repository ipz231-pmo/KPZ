namespace VisitorTask;

// Component base class
interface INode
{
    public string InnerHTML { get; }
    public string OuterHTML { get; }
}

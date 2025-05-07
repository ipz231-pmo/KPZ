namespace VisitorTask;

delegate void EventCallback(INode sender);

interface INode
{
    string InnerHTML { get; }
    string OuterHTML { get; }
    void AddEventListener(string eventType, EventCallback callback);
    void TriggerEvent(string eventType);
}

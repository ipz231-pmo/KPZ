using System.Windows.Input;

namespace LightHTML;


interface INode
{
    string InnerHTML { get; }
    string OuterHTML { get; }
    void AddEventListener(string eventType, Action callback);
    void AddEventListener(string eventType, ICommand cmd);
    void TriggerEvent(string eventType);
    void OnBeforeEvent(string eventType);
    void OnAfterEvent(string eventType);
}

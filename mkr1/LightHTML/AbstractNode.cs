using System.Windows.Input;

namespace LightHTML;

abstract class AbstractNode : INode
{
    public abstract string InnerHTML { get; }
    public abstract string OuterHTML { get; }

    protected Dictionary<string, List<Action>> eventListenersActions = [];
    protected Dictionary<string, List<ICommand>> eventListenersCommands = [];

    public void AddEventListener(string eventType, Action callback)
    {
        if (!eventListenersActions.ContainsKey(eventType))
            eventListenersActions[eventType] = [];
        eventListenersActions[eventType].Add(callback);
    }
    public void AddEventListener(string eventType, ICommand cmd)
    {
        if (!eventListenersCommands.ContainsKey(eventType))
            eventListenersCommands[eventType] = [];
        eventListenersCommands[eventType].Add(cmd);
    }

    public void TriggerEvent(string eventType)
    {
        if (eventListenersActions.TryGetValue(eventType, out var listeners))
        {
            foreach (var callback in listeners)
                callback();
        }
        if (eventListenersCommands.TryGetValue(eventType, out var cmds))
        {
            foreach (var cmd in cmds)
                cmd.Execute(this);
        }
    }
}

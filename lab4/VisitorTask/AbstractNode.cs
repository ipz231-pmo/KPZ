using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorTask;

abstract class AbstractNode : INode
{
    private Dictionary<string, List<EventCallback>> eventListeners = [];

    public abstract string InnerHTML { get; }
    public abstract string OuterHTML { get; }

    public void AddEventListener(string eventType, EventCallback callback)
    {
        if (!eventListeners.ContainsKey(eventType))
            eventListeners[eventType] = [];
        eventListeners[eventType].Add(callback);
    }

    public void TriggerEvent(string eventType)
    {
        if (eventListeners.TryGetValue(eventType, out var listeners))
        {
            foreach (var callback in listeners)
                callback(this);
        }
    }
}

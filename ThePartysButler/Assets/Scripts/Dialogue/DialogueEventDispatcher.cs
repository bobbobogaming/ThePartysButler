using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Event Dispatcher")]
public class DialogueEventDispatcher : ScriptableObject
{
    public event Action<string> EventDispatched;

    public void DispatchEvent(string eventName) {  EventDispatched?.Invoke(eventName); }
}

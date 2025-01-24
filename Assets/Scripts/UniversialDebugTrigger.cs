using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UniversialDebugTrigger : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent DebugEvents;
    public System.Action DebugEventAction;

    public void Trigger()
    {
        DebugEvents.Invoke();
        DebugEventAction?.Invoke();
    }
}

#if UNITY_EDITOR

[CustomEditor(typeof(UniversialDebugTrigger))]
class UniversialDebugTriggerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        UniversialDebugTrigger debugger = (UniversialDebugTrigger)target;

        if (GUILayout.Button("Trigger"))
            debugger.Trigger();
    }
}

#endif

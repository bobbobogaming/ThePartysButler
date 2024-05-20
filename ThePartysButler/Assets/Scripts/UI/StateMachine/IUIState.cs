using UnityEngine;
public abstract class IUIState: MonoBehaviour
{
    public abstract void OnEnter();
    public abstract void OnLeave();
    public abstract string GetSateName();
}

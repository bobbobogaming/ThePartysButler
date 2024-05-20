using UnityEngine;
using UnityEngine.XR;

public class UIStateContext : MonoBehaviour {
    [SerializeField] private IUIState UIState;

    public void ChangeState(IUIState newState) {
        UIState.OnLeave();

        UIState = newState;
        UIState.OnEnter();
    }
}

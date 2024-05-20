using UnityEngine;

public class UIState : IUIState {
    [SerializeField] public string stateName;
    [SerializeField] private MonoBehaviour[] forEnable;
    [SerializeField] private MonoBehaviour[] forDisable;

    public override void OnEnter() {
        foreach (var item in forDisable) {
            item.enabled = false;
        }
        foreach (var item in forEnable) {
            item.enabled = true;
        }
    }

    public override void OnLeave() {
        foreach (var item in forDisable) {
            item.enabled = true;
        }
        foreach (var item in forEnable) {
            item.enabled = false;
        }
    }

    public override string GetSateName() {
        return stateName;
    }
}

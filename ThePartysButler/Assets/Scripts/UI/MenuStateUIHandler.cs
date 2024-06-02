using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStateUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject UIObj;
    [SerializeField] private IUIState playState;

    void OnEnable() {
        UIObj.SetActive(true);
        gameObject.GetComponentInChildren<Button>().Select();
    }
    void OnDisable() {
        UIObj.SetActive(false);
    }
    void OnCloseMenu() {
        if (enabled) {
            GetComponent<UIStateContext>().ChangeState(playState);
        }
    }
}

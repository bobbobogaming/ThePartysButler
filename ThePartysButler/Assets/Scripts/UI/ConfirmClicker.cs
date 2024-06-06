using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ConfirmClicker : MonoBehaviour
{
    void OnConfirm(InputValue inputValue)
    {
        var buttonGameObj = EventSystem.current.currentSelectedGameObject;
        if (buttonGameObj == null) { return; }
        buttonGameObj.GetComponent<Button>().onClick.Invoke();
    }
}

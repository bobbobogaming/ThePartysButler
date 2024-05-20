using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenMenuHandler : MonoBehaviour
{
    [SerializeField] private UIStateContext uiStateContext;
    [SerializeField] private IUIState menuState;
    void OnOpenMenu(InputValue inputValue) {
        uiStateContext.ChangeState(menuState);
    }
}

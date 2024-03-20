using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateSelector : MonoBehaviour
{
    [SerializeField] private BoxCollider2D selectorCollider;

    void OnAltActionDual(InputValue inputValue)
    {
        selectorCollider.enabled = !selectorCollider.enabled;
    }
}

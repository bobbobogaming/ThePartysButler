using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateSelector : MonoBehaviour
{
    [SerializeField] private BoxCollider2D selectorCollider;
    [SerializeField] private SpriteRenderer sprite;

    void OnAltActionDual(InputValue inputValue)
    {
        selectorCollider.enabled = !selectorCollider.enabled;

        if (selectorCollider.enabled)
        {
            sprite.color = Color.red;
        }
        else 
        {
            sprite.color = new Color(1, 0, 0, 0.5f);
        }
    }
}

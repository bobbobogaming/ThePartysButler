using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCharacter : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    #nullable enable
    private string? WhenStopped;
    #nullable disable

    void Start() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator == null) { return; }

        //if (rb.velocity.magnitude < 0.1f) { animator.Play("playerSpin"); return; }
        if (rb.velocity.x > 0.1f)
        {
            animator.Play("playerRight");
            WhenStopped = "playerRightStill";
            return;
        }
        if (rb.velocity.x < -0.1f)
        {
            animator.Play("playerLeft");
            WhenStopped = "playerLeftStill";
            return;
        }
        if (rb.velocity.y > 0.1f)
        {
            animator.Play("playerBackward");
            WhenStopped = null;
            return;
        }
        if (rb.velocity.y < -0.1f)
        {
            animator.Play("playerForwar");
            WhenStopped = null;
            return;
        }
        
        if (rb.velocity.magnitude < 0.1f && !string.IsNullOrEmpty(WhenStopped))
            { animator.Play(WhenStopped); return; }
    }
}

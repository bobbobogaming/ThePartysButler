using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    public float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.magnitude == 0)
        {
            rb.velocity = Vector3.zero;
        }
        rb.AddForce(movement * speed * Time.deltaTime);
    }

    void OnMove(InputValue inputValue)
    {
        movement = inputValue.Get<Vector2>();
    }
}

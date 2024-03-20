using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class MoveSelector : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform selector;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 0.05)
        {
        Vector2 selectorPos = new Vector2((float)Max(-1,Min(1,rb.velocity.x)), (float)Max(-1,Min(1,rb.velocity.y)));
        Vector2 roundedPosition = new Vector2((float)rb.position.x, (float)rb.position.y);
        selector.position = selectorPos + roundedPosition;
        }
        selector.position = (Vector2) Vector2Int.RoundToInt(selector.position);
    }
}

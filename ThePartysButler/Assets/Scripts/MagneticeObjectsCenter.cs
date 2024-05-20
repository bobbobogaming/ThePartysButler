using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticeObjectsCenter : MonoBehaviour
{
    [SerializeField] private float magnetForce;
    [SerializeField] private InventoryObject inventory;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Pickup") || collision.GetType() == typeof(CircleCollider2D)) { return; }
        var itemDescription = collision.GetComponent<ItemDescription>();
        inventory.AddItem(itemDescription.itemType.type);
        Destroy(collision.gameObject);
        return;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Pickup") || collision.GetType() == typeof(BoxCollider2D)) { return; }
        collision.attachedRigidbody.AddForce((gameObject.transform.position - collision.transform.position) * magnetForce);
    }
}

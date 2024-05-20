using UnityEngine;

public class BreakHandler : MonoBehaviour
{
    [SerializeField] private int health;
    void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.CompareTag("Selector")) {
            return;
        }

        if (--health > 0) { return; }

        IDropBehaviour dropBehaviour = GetComponent<IDropBehaviour>();
        dropBehaviour?.SpawnDrops();

        Destroy(gameObject);
    }
}

using UnityEngine;

public class DropSpawner : MonoBehaviour, IDropBehaviour
{
    [SerializeField] private ItemType dropType;
    [SerializeField] private GameObject dropPreset;
    [SerializeField] private int minDropCount;
    [SerializeField] private float[] subsequentChances;
    public void SpawnDrops() {
        foreach (var item in subsequentChances)
        {
            if (Random.Range(0,1f) < item)
            {
                minDropCount++;
            }
            else 
            {
                break;
            }
        }

        for (var i = 0; i < minDropCount; i++) 
        {
            var dx = Random.Range(-1f, 1f);
            var dy = Random.Range(-1f, 1f);
            var location = new Vector3(dx,dy, gameObject.transform.position.z) + gameObject.transform.position;
            var dropIntance = Instantiate(dropPreset, location,Quaternion.identity);
            dropIntance.AddComponent<ItemDescription>().itemType = dropType;
            dropIntance.GetComponent<Rigidbody2D>().AddForce(new Vector2(dx,dy));
        }
    }
}

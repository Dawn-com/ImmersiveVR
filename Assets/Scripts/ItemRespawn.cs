using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;

    void Start()
    {
        if (TeleportMemory.hasItem)
        {
            Instantiate(itemPrefab, transform.position, transform.rotation);
        }
    }
}

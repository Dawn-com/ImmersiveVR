using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject gemPrefab;
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        if (GameEvents3.current != null)
        {
            GameEvents3.current.eventAllCradlesActive += SpawnGem;
        }
    }

    private void OnDestroy()
    {
        if (GameEvents3.current != null)
        {
            GameEvents3.current.eventAllCradlesActive -= SpawnGem;
        }
    }

    private void SpawnGem()
    {
        Instantiate(gemPrefab, spawnPoint.position, Quaternion.identity);
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPortal : MonoBehaviour
{
    [SerializeField] string sceneName = "NextScene";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TeleportItem"))
        {
            TeleportMemory.hasItem = true;

            Destroy(other.gameObject);

            SceneManager.LoadScene(sceneName);
        }
    }
}
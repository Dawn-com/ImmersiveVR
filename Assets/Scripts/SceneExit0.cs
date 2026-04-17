using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit0 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with: " + other.name);

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
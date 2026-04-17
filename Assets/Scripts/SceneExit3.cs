using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(0);
    }
}

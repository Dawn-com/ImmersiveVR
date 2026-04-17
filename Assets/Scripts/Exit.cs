using UnityEngine;
using UnityEngine.InputSystem; // new Input System

public class Exit : MonoBehaviour
{
    // Reference to your separate PauseMenuVR script
    public PauseMenuVR pauseMenu;

    void Update()
    {
        // Only exit if the menu is open
        if (pauseMenu != null && pauseMenu.IsPaused() && Keyboard.current.tabKey.wasPressedThisFrame)
        {
            Debug.Log("Exiting application...");
            Application.Quit();

            // Stop play mode in Editor for testing
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}

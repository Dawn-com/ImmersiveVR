using UnityEngine;
using UnityEngine.InputSystem; // new Input System

public class PauseMenuVR : MonoBehaviour
{
    public GameObject menuCanvas;
    public Transform playerHead;
    public float distanceFromPlayer = 2f;

    private bool isPaused = false;

    // Drag the GameObject that has Restart script here
    public Restart restartScript;

    void Start()
    {
        menuCanvas.SetActive(false);
    }

    void Update()
    {
        // Toggle menu with Enter or M
        if (Keyboard.current.enterKey.wasPressedThisFrame || Keyboard.current.mKey.wasPressedThisFrame)
        {
            ToggleMenu();
        }

        // Restart scene with R only if menu is open
        if (isPaused && Keyboard.current.rKey.wasPressedThisFrame)
        {
            if (restartScript != null)
                restartScript.RestartScene();
            else
                Debug.LogError("Restart script not assigned in Inspector!");
        }
    }

    void ToggleMenu()
    {
        isPaused = !isPaused;
        menuCanvas.SetActive(isPaused);

        if (isPaused)
        {
            ShowMenu();
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    void ShowMenu()
    {
        Vector3 forward = playerHead.forward;
        Vector3 position = playerHead.position + forward * distanceFromPlayer;
        menuCanvas.transform.position = position;

        menuCanvas.transform.LookAt(playerHead);
        menuCanvas.transform.Rotate(0, 180, 0);
    }
    public bool IsPaused()
    {
        return isPaused;
    }
}
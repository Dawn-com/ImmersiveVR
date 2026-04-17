using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    public event Action eventCradleActive;
    public event Action eventAllCradlesActive;

    private int cradleCount = 0;
    private int totalCradles = 4;

    private void Awake()
    {
        current = this;
    }

    public void CradleActivated()
    {
        cradleCount++;
        eventCradleActive?.Invoke();

        if (cradleCount >= totalCradles)
        {
            eventAllCradlesActive?.Invoke();
        }
    }
}
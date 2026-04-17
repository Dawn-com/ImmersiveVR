using System;
using UnityEngine;

public class GameEvents3 : MonoBehaviour
{
    public static GameEvents3 current;

    public event Action eventAllCradlesActive;

    private void Awake()
    {
        current = this;
    }

    public void AllCradlesActivated()
    {
        eventAllCradlesActive?.Invoke();
    }
}
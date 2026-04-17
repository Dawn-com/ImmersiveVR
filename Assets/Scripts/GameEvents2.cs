using System;
using UnityEngine;

public class GameEvents2 : MonoBehaviour
{
    public static GameEvents2 current;

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
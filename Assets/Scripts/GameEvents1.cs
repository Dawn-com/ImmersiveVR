using System;
using UnityEngine;

public class GameEvents1 : MonoBehaviour
{
    public static GameEvents1 current;

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
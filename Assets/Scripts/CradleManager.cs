using UnityEngine;

public class CradleManager : MonoBehaviour
{
    public static CradleManager Instance;

    private int completedCradles = 0;
    public int totalCradles = 4;

    private void Awake()
    {
        Instance = this;
    }

    public void CradleCompleted()
    {
        completedCradles++;

        if (completedCradles >= totalCradles)
        {
            GameEvents3.current.AllCradlesActivated();
        }
    }
}
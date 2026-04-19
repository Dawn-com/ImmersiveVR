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
        Debug.Log("Cradle completed! Total now: " + completedCradles);

        if (completedCradles >= totalCradles)
        {
            Debug.Log("ALL CRADLES COMPLETE");
            GameEvents3.current.AllCradlesActivated();
        }
    }
}
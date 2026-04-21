using UnityEngine;

public class CradleManager : MonoBehaviour
{
    public static CradleManager Instance;

    private int totalBallsInside = 0;
    public int requiredTotalBalls = 11;

    private bool isComplete = false;

    private void Awake()
    {
        Instance = this;
    }

    public void BallEntered()
    {
        totalBallsInside++;
        CheckCompletion();
    }

    public void BallExited()
    {
        totalBallsInside--;
        CheckCompletion();
    }

    private void CheckCompletion()
    {
        if (!isComplete && totalBallsInside >= requiredTotalBalls)
        {
            isComplete = true;
            Debug.Log("ALL CRADLES COMPLETE");
            GameEvents3.current.AllCradlesActivated();
        }
        else if (isComplete && totalBallsInside < requiredTotalBalls)
        {
            isComplete = false;
        }
    }
}
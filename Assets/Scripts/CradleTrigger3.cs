using UnityEngine;

public class CradleTrigger3 : MonoBehaviour
{
    public CarColor cradleColor;

    private int currentBalls = 0;
    private bool isActivated = false;

    private int RequiredBalls
    {
        get
        {
            return cradleColor switch
            {
                CarColor.Red => GameConfig.RedCars,
                CarColor.Yellow => GameConfig.YellowCars,
                CarColor.Brown => GameConfig.BrownCars,
                CarColor.None => GameConfig.RandomBalls, 
                _ => 0
            };
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("cradleBall")) return;

        currentBalls++;

        if (!isActivated && currentBalls >= RequiredBalls)
        {
            isActivated = true;
            CradleManager.Instance.CradleCompleted();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("cradleBall"))
        {
            currentBalls--;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

public class CradleTrigger3 : MonoBehaviour
{
    public CarColor cradleColor;

    private HashSet<Transform> ballsInside = new HashSet<Transform>();
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

        ballsInside.Add(other.transform);

        CheckActivation();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("cradleBall")) return;

        ballsInside.Remove(other.transform);

        CheckActivation();
    }

    private void CheckActivation()
    {
        if (!isActivated && ballsInside.Count >= RequiredBalls)
        {
            isActivated = true;
            CradleManager.Instance.CradleCompleted();
        }
        else if (isActivated && ballsInside.Count < RequiredBalls)
        {
            isActivated = false;
            // Optional (only if you want dynamic undo):
            // CradleManager.Instance.CradleUncompleted();
        }
    }
}
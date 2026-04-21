using System.Collections.Generic;
using UnityEngine;

public class CradleTrigger3 : MonoBehaviour
{
    private HashSet<Transform> ballsInside = new HashSet<Transform>();

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("cradleBall")) return;

        // Only count if it's a new ball
        if (ballsInside.Add(other.transform))
        {
            CradleManager.Instance.BallEntered();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("cradleBall")) return;

        // Only count if it was actually inside
        if (ballsInside.Remove(other.transform))
        {
            CradleManager.Instance.BallExited();
        }
    }
}
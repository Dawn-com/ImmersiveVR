using UnityEngine;

public class CradleTrigger2 : MonoBehaviour
{
    public int requiredBalls = 4;
    private int currentBalls = 0;
    private bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cradleBall"))
        {
            currentBalls++;

            if (!isActivated && currentBalls >= requiredBalls)
            {
                isActivated = true;
                GameEvents2.current.AllCradlesActivated();
            }
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
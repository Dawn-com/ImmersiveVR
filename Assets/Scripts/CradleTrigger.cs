using UnityEngine;

public class CradleTrigger : MonoBehaviour
{
    private bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isActivated && other.CompareTag("cradleBall"))
        {
            isActivated = true;
            GameEvents.current.CradleActivated();
        }
    }
}

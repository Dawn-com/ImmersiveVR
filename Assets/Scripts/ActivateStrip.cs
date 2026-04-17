using UnityEngine;

public class ActivateStrip : MonoBehaviour
{
    [SerializeField] GameObject ActiveStrip;

    private void Start()
    {
        ActiveStrip.SetActive(false);
        GameEvents.current.eventCradleActive += Activate;
    }

    private void Activate()
    {
        ActiveStrip.SetActive(true);
    }
}

using UnityEngine;

public class ActivateStrip3 : MonoBehaviour
{
    [SerializeField] GameObject ActiveStrip;

    private void Start()
    {
        ActiveStrip.SetActive(false);

        if (GameEvents3.current != null)
        {
            GameEvents3.current.eventAllCradlesActive += Activate;
        }
    }

    private void OnDestroy()
    {
        if (GameEvents3.current != null)
        {
            GameEvents3.current.eventAllCradlesActive -= Activate;
        }
    }

    private void Activate()
    {
        ActiveStrip.SetActive(true);
    }
}
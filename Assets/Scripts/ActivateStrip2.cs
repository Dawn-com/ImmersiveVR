using UnityEngine;

public class ActivateStrip2 : MonoBehaviour
{
    [SerializeField] GameObject ActiveStrip;

    private void Start()
    {
        ActiveStrip.SetActive(false);

        if (GameEvents2.current != null)
        {
            GameEvents2.current.eventAllCradlesActive += Activate;
        }
    }

    private void OnDestroy()
    {
        if (GameEvents2.current != null)
        {
            GameEvents2.current.eventAllCradlesActive -= Activate;
        }
    }

    private void Activate()
    {
        ActiveStrip.SetActive(true);
    }
}
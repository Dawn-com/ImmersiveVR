using UnityEngine;

public class ActivateStrip1 : MonoBehaviour
{
    [SerializeField] GameObject ActiveStrip;

    private void Start()
    {
        ActiveStrip.SetActive(false);

        if (GameEvents1.current != null)
        {
            GameEvents1.current.eventAllCradlesActive += Activate;
        }
    }

    private void OnDestroy()
    {
        if (GameEvents1.current != null)
        {
            GameEvents1.current.eventAllCradlesActive -= Activate;
        }
    }

    private void Activate()
    {
        ActiveStrip.SetActive(true);
    }
}
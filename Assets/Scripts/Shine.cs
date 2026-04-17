using UnityEngine;

public class Shine : MonoBehaviour
{
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        GameEvents.current.eventAllCradlesActive += Glow;
    }

    private void Glow()
    {
        if (rend != null)
        {
            rend.material.color = Color.yellow;
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.eventAllCradlesActive -= Glow;
    }
}
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private Renderer rend;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = Color.yellow;
    }
}

using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 2f;
    private bool shouldMove = false;

    private void Start()
    {
        if (GameEvents1.current != null)
        {
            GameEvents1.current.eventAllCradlesActive += StartMoving;
        }
        else
        {
            Debug.LogError("GameEvents1.current is NULL on " + gameObject.name);
        }
    }

    private void OnDestroy()
    {
        if (GameEvents1.current != null)
        {
            GameEvents1.current.eventAllCradlesActive -= StartMoving;
        }
    }

    void Update()
    {
        if (shouldMove)
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
    }

    void StartMoving()
    {
        Debug.Log(gameObject.name + " started moving");
        shouldMove = true;
    }
}
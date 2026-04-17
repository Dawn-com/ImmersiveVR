using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 90f; // degrees per second
    public float moveTime = 3f;
    public float turnTime = 1f;

    private float timer = 0f;
    private bool isTurning = false;

    void Update()
    {
        timer += Time.deltaTime;

        if (!isTurning)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (timer >= moveTime)
            {
                timer = 0f;
                isTurning = true;
            }
        }
        else
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime, Space.Self);

            if (timer >= turnTime)
            {
                timer = 0f;
                isTurning = false;
            }
        }
    }
}

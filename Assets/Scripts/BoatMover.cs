using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatMover : MonoBehaviour
{
    [Header("Boat Settings")]
    public float speed = 2f;                   // Boat forward speed
    public Vector3 playerDetectionSize = new Vector3(3f, 2f, 3f); // Area above boat to detect players
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;                 // Keep boat kinematic
    }

    void FixedUpdate()
    {
        // Move the boat
        Vector3 movement = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // Detect players manually above the boat
        Collider[] hits = Physics.OverlapBox(transform.position + Vector3.up, playerDetectionSize / 2f);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                // Move the player along with the boat
                hit.transform.position += movement;
            }
        }
    }

    // Optional: visualize the detection box in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position + Vector3.up, playerDetectionSize);
    }

    public void StopBoat()
    {
        // Stop the boat
        Debug.Log("Boat has stopped!");
        // Optionally, set speed to 0 or stop moving
        speed = 0f;
    }
}
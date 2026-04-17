using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BoatMover1 : MonoBehaviour
{
    [Header("Boat Settings")]
    public float speed = 2f;

    [Header("Movement Control")]
    public Transform stopPoint;

    private Rigidbody rb;
    private bool isMoving = false;

    private List<Transform> carriedObjects = new List<Transform>();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        if (GameEvents2.current != null)
        {
            GameEvents2.current.eventAllCradlesActive += StartBoat;
        }
    }

    void OnDestroy()
    {
        if (GameEvents2.current != null)
        {
            GameEvents2.current.eventAllCradlesActive -= StartBoat;
        }
    }

    void FixedUpdate()
    {
        if (!isMoving) return;

        Vector3 movement = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        // Move carried objects manually (extra safety)
        foreach (Transform t in carriedObjects)
        {
            if (t != null)
                t.position += movement;
        }

        if (Vector3.Distance(transform.position, stopPoint.position) < 0.5f)
        {
            StopBoat();
        }
    }

    void StartBoat()
    {
        Debug.Log("Boat started!");
        isMoving = true;
    }

    public void StopBoat()
    {
        Debug.Log("Boat has stopped!");
        isMoving = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CarryItem"))
        {
            if (!carriedObjects.Contains(other.transform))
            {
                carriedObjects.Add(other.transform);
                other.transform.SetParent(transform); // attach to boat
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CarryItem"))
        {
            carriedObjects.Remove(other.transform);
            other.transform.SetParent(null); // detach if needed
        }
    }
}
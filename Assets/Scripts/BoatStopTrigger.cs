using UnityEngine;

public class BoatStopTrigger : MonoBehaviour
{
    private BoatMover1 boat;

    private void Start()
    {
        boat = GetComponent<BoatMover1>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BoatStop"))
        {
            boat.StopBoat();
        }
    }
}

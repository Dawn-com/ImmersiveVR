using UnityEngine;

public class BoatStop : MonoBehaviour
{
    public BoatMover boat; // drag your Boat GameObject here in Inspector

    private void OnTriggerEnter(Collider other)
    {
        // Check if the boat entered this trigger
        if (other.CompareTag("Boat"))
        {
            if (boat != null)
            {
                boat.StopBoat(); // Call the method on the BoatMover script
            }
        }
    }
}

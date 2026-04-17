using UnityEngine;
using UnityEngine.XR;

public class HMDInputManager : MonoBehaviour
{
    [SerializeField] GameObject VRRig;
    [SerializeField] GameObject FPSRig;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (XRSettings.isDeviceActive || XRSettings.loadedDeviceName == "OpenXR Display")
        {
            Debug.Log("VR Rig Active Using Device: " + XRSettings.loadedDeviceName);
            FPSRig.SetActive(false);
        }
        else
        {
            Debug.Log("Using FPS Rig");
            VRRig.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

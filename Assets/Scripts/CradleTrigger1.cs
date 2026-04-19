using System.Collections.Generic;
using UnityEngine;

public class CradleTrigger1 : MonoBehaviour
{
    private HashSet<string> requiredItems = new HashSet<string>()
    {
        "WindGem",
        "WaterDiamond",
        "StarBethlehem"
    };

    private HashSet<string> collectedItems = new HashSet<string>();

    private bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.name);

        cradleItem item = other.GetComponent<cradleItem>();
        if (item == null) return;

        Debug.Log("Item detected: " + item.itemId);

        if (requiredItems.Contains(item.itemId))
        {
            collectedItems.Add(item.itemId);
        }

        CheckActivation();
    }

    private void OnTriggerExit(Collider other)
    {
        cradleItem item = other.GetComponent<cradleItem>();
        if (item == null) return;

        Debug.Log("Exited: " + item.itemId);

        collectedItems.Remove(item.itemId);

        isActivated = false;
    }

    private void CheckActivation()
    {
        if (isActivated) return;

        foreach (string item in requiredItems)
        {
            if (!collectedItems.Contains(item))
                return;
        }

        isActivated = true;
        Debug.Log("ALL ITEMS PLACED ? TRIGGERING EVENT");

        GameEvents1.current.AllCradlesActivated();
    }
}
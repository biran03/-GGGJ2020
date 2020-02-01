using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isEmpty : MonoBehaviour
{
    public GameObject heldItem;
    public bool Empty;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            Empty = false;
 
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Grabbable")
        {
            Empty = true;
            heldItem = other.gameObject;
        }
    }
    public void DestroyTool()
    {
        Destroy(heldItem);
    }

}

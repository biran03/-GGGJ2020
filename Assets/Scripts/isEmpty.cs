using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isEmpty : MonoBehaviour
{
    public GameObject Drawer;
    public GameObject TriggerSpawn;
    public bool Empty;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag== "Grabbable")
        {
            Empty = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Grabbable")
        {
            Empty = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

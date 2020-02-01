﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNew : MonoBehaviour
{
    public isEmpty triggerCheck;
    public GameObject Drawer;
    [SerializeField] private ObjectInfo[] objects;  // fill in editor

    GameObject GetRandomObject(ObjectInfo[] objects)
    {
        float chance = Random.Range(0, 100); // random (0 to 99) %

        foreach (ObjectInfo obj in objects)
        {
            // Check if random is in chance
            if (chance < obj.chance)
            {
                return obj.obj; // returns object
            }

            // Fix chance for next item
            else chance -= (int)obj.chance;
        }
        return null;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            GameObject spawnObj = Instantiate(GetRandomObject(objects),Drawer.transform.position,Quaternion.identity);
            spawnObj.transform.SetParent(Drawer.transform, true);

        }
    }


    void spawnRandom()
    {
        if (triggerCheck.Empty)
        {
            
        }

    }
// Update is called once per frame
[System.Serializable]
public struct ObjectInfo
{ // structure for object information
    public GameObject obj; // Prefab
    public short chance; // (0 to 99) %
}
}
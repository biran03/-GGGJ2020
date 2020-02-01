using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBelt : MonoBehaviour {

    public GameObject[] robotPrefabs;



    private void Start()
    {

        Object[] robotPrefabs = Resources.LoadAll("Prefabs/Robots");
        this.robotPrefabs = new GameObject[robotPrefabs.Length];
        for (int i = 0; i < robotPrefabs.Length; ++i)
        {
            this.robotPrefabs[i] = robotPrefabs[i] as GameObject;
        }
    }
    // Instantiates new robot and returns it.
    public GameObject LoadNewRobot()
    {
        int prefabIndex = Random.Range(0, robotPrefabs.Length);
        GameObject prefab = robotPrefabs[prefabIndex];
        GameObject newRobot = Instantiate(prefab);
        return newRobot;
    }
}

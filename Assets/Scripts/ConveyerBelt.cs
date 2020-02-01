using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBelt : MonoBehaviour {

    public GameObject[] robotPrefabs;

    [SerializeField]
    Vector3 position;

    public System.Action<RobotState> OnSpawnedNewRobot;

    RobotState currentRobot;

    private void Start()
    {
        Object[] robotPrefabs = Resources.LoadAll("Prefabs/Robots");
        this.robotPrefabs = new GameObject[robotPrefabs.Length];
        for (int i = 0; i < robotPrefabs.Length; ++i)
        {
            this.robotPrefabs[i] = robotPrefabs[i] as GameObject;
        }
        LoadNewRobot();
    }
    // Instantiates new robot and returns it.
    public void LoadNewRobot()
    {
        int prefabIndex = Random.Range(0, robotPrefabs.Length);
        GameObject prefab = robotPrefabs[prefabIndex];
        GameObject newRobot = Instantiate(prefab);
        currentRobot = newRobot.GetComponent<RobotState>();
        currentRobot.OnStateChange += (RobotState.States state) =>
        {
            if (state == RobotState.States.LEAVING)
            {
                StartCoroutine(StartSpawningNewRobot());
            }
        };
        OnSpawnedNewRobot?.Invoke(currentRobot);
    }

    IEnumerator StartSpawningNewRobot()
    {
        // Or if robots had point value, whatever.
        yield return new WaitForSeconds(2.0f);
        LoadNewRobot();
        yield return new WaitForEndOfFrame();
        currentRobot.Enter();
    }
}

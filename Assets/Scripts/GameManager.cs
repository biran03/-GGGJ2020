using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    ConveyerBelt conveyerBelt;

    RobotState currentRobot;

	// Use this for initialization
	void Start () {
        StartCoroutine(StartSpawningNewRobot());
	}

    void OnCurrentRobotDone(RobotState.States robotState)
    {
        if (robotState == RobotState.States.LEAVING)
        {
            currentRobot.OnStateChange -= OnCurrentRobotDone;
            StartCoroutine(StartSpawningNewRobot());
        }
    }

    IEnumerator StartSpawningNewRobot()
    {
        yield return new WaitForSeconds(2.0f);
        GameObject newRobotObject = conveyerBelt.LoadNewRobot();
        currentRobot = newRobotObject.GetComponent<RobotState>();
        currentRobot.OnStateChange += OnCurrentRobotDone;
        yield return new WaitForEndOfFrame();
        currentRobot.Enter();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

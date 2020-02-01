using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    ConveyerBelt conveyerBelt;

    [SerializeField]
    Timer timer;

    [SerializeField]
    Score score;


	// Use this for initialization
	void Start () {
        timer.OnTimeEnd += GameOver;
        conveyerBelt.OnSpawnedNewRobot += OnNextRobot;
	}

    void GameOver()
    {
        Debug.Log("Game Over");
    }

    void OnNextRobot(RobotState robotState)
    {
        score.AddToScore(100);
    }
}

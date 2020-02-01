using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {

    [SerializeField]
    Text scoreText;

    int currentScore;


    public void AddToScore(int score)
    {
        currentScore += score;
        scoreText.text = $"Score:{currentScore.ToString()}";
    }

}

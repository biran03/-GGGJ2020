using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    float currentTime = 0f; //0 floating
    float startingTime = 500f; //500 floating

    [SerializeField] Text countdownText;

    public event System.Action OnTimeEnd;


    void Start()
    {
        currentTime = startingTime; //when game starts, current time is the starting time
        print(currentTime);
    }

    void Update() //decrease time
    {
        currentTime -= 1 * Time.deltaTime; // deltaTime allows decrease time by 1 second rather than by frame
        countdownText.text = currentTime.ToString();

        if (currentTime <= 0)
        {
            currentTime = 0;
            OnTimeEnd?.Invoke();
        }
    }
}

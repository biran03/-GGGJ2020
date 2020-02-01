using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotState : MonoBehaviour {

    public enum States
    {
        ENTERING,
        SITTING,
        LEAVING
    };

    States currentState;

    // When creating Robot prefabs, assign the open areas these open slots.
    public GameObject[] openSlots;
    bool[] slotValues;

    public System.Action<States> OnStateChange;

    private void Start()
    {
        slotValues = new bool[openSlots.Length];
        for (int i = 0; i < openSlots.Length; ++i)
        {
            slotValues[i] = false;
        }
    }

    public void Enter()
    {
        currentState = States.ENTERING;
        OnStateChangeEventHandler();
    }


    // To be called when snap or detach, OnJointBreak or OnSnap it will call update slot with state.
    public void UpdateSlot(GameObject gameObject, bool state)
    {
        int amountTrue = 0;
        for (int i = 0; i < openSlots.Length; ++i)
        {
            if (slotValues[i])
            {
                amountTrue += 1;
            }
            if (openSlots[i] == gameObject)
            {
                slotValues[i] = true;
                amountTrue += 1;
            }
        }
        if (amountTrue == openSlots.Length)
        {
            Finish();
        }
    }

    // Called when all parts are done.
    public void Finish()
    {
        currentState = States.LEAVING;
        OnStateChangeEventHandler();
    }

    private void OnStateChangeEventHandler()
    {
        if (OnStateChange != null)
        {
            OnStateChange?.Invoke(currentState);
        }
    }
}

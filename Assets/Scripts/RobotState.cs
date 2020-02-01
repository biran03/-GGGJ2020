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
    // Simply to know how many there are total.
    public RobotSlot[] openSlots;
    int slotsFilled = 0;

    public System.Action<States> OnStateChange;

    private void Start()
    {
        for (int i = 0; i < openSlots.Length; ++i)
        {
            openSlots[i].OnAttachUpdate += SlotFilled;
        }
    }

    public void Enter()
    {
        currentState = States.ENTERING;
        OnStateChange?.Invoke(currentState);
    }


    private void SlotFilled(bool slotUpdate)
    {
        if (slotUpdate)
        {
            slotsFilled += 1;
            if (slotsFilled == openSlots.Length)
            {
                Finish();
            }
        }
        else
        {
            slotsFilled -= 1;
            // Not really needed to unsubscribe, since not pooling they'd be destroyed.
            for (int i = 0; i < openSlots.Length; ++i)
            {
                openSlots[i].OnAttachUpdate -= SlotFilled;
            }
        }
    }

    // Called when all slots are filled.
    public void Finish()
    {
        currentState = States.LEAVING;
        OnStateChange?.Invoke(currentState);
    }
}

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
    [SerializeField]
    RobotSlot[] openSlots;
    int slotsFilled = 0;

    public System.Action<States> OnStateChange;

    private void Start()
    {
        openSlots = GetComponentsInChildren<RobotSlot>();
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
                // unsubscribe so nothing somehow detaches them on their way out.
                for (int i = 0; i < openSlots.Length; ++i)
                {
                    openSlots[i].OnAttachUpdate -= SlotFilled;
                }
            }
        }
        else
        {
            slotsFilled -= 1;
            
        }
    }

    // Called when all slots are filled.
    public void Finish()
    {
        currentState = States.LEAVING;
        OnStateChange?.Invoke(currentState);
    }
}

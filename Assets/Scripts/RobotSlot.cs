using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSlot : MonoBehaviour {

    public bool Attached;   
    public System.Action<bool> OnAttachUpdate;

    // To be called when snap or detach, OnJointBreak or OnSnap it will call update slot with state.
    public void Attach()
    {
        Attached = true;
        OnAttachUpdate?.Invoke(true);
    }

    public void Detach()
    {
        Attached = false;
        OnAttachUpdate?.Invoke(false);
    }
}

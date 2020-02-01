using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSlot : MonoBehaviour {

    bool attached;
    public System.Action<bool> OnAttachUpdate;

    // To be called when snap or detach, OnJointBreak or OnSnap it will call update slot with state.
    public void Attach()
    {
        attached = true;
        OnAttachUpdate?.Invoke(true);
    }

    public void Detach()
    {
        attached = false;
        OnAttachUpdate?.Invoke(false);
    }
}

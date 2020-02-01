using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimator : MonoBehaviour {

    Animator animator;
    RobotState robotState;
	// Use this for initialization
	void Awake () {
        animator = GetComponent<Animator>();
        robotState = GetComponent<RobotState>();
        robotState.OnStateChange += UpdateAnimationState;
	}

    void UpdateAnimationState(RobotState.States state)
    {
        animator.SetTrigger(state.ToString());
    }
}

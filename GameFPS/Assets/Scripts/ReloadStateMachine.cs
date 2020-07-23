using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadStateMachine : StateMachineBehaviour {

    public float reloadTime = 0.7f;
    bool hasReloaded = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        hasReloaded = false;


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        if (hasReloaded) return;

        if (stateInfo.normalizedTime >= reloadTime)
        {
            animator.GetComponent<AKM>().Reload();
            hasReloaded = true;
        }
    }

    // OnStateExit is called when a transition ends an the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        hasReloaded = false;
    }

}

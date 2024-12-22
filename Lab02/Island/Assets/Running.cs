using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : StateMachineBehaviour
{
    private UnityEngine.AI.NavMeshAgent _nav;
    private float latestDirectionChangeTime;
    public float directionChangeTime = 5f;
    public float WolfVelocity = 50f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _nav = animator.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator.SetInteger("nextState", 0);
        _nav.ResetPath();
        Vector3 movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized;
        Vector3 movementPerSecond = movementDirection * WolfVelocity;
        Vector3 position = new Vector3(animator.rootPosition.x + (movementPerSecond.x), animator.rootPosition.y, animator.rootPosition.z + (movementPerSecond.z));
        _nav.SetDestination(position);
        latestDirectionChangeTime = Time.time;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            _nav.ResetPath();
            animator.SetInteger("nextState", Random.Range(1, 4));
        }
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}
}

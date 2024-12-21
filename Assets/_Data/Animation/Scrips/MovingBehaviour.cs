using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MovingBehaviour : StateMachineBehaviour
{
    [SerializeField] protected NavMeshAgent meshAgent;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (this.meshAgent != null) return;
        this.meshAgent = animator.transform.parent.GetComponent<NavMeshAgent>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("isMovingF", this.meshAgent.speed);
    }
}

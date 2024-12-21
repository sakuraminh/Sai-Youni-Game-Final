using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    [SerializeField] private float _timeUntilBored;
    [SerializeField] private int _numberOfBoredAnimations;
    [SerializeField] private bool _isBored;
    [SerializeField] private float _idleTimer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.ResetIdle(animator);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (this._isBored == false)
        {
            this._idleTimer += Time.deltaTime;
            if (this._idleTimer > this._timeUntilBored)
            {
                this._isBored = true;
                int randomIndex = Random.Range(1, this._numberOfBoredAnimations + 1);
                animator.SetFloat("BoredAnimation", randomIndex);
            }
        }
        else if (stateInfo.normalizedTime % 1 > 0.98)
        {
            this.ResetIdle(animator);
        }
    }

    private void ResetIdle(Animator animator)
    {
        this._isBored = false;
        this._idleTimer = 0;

        animator.SetFloat("BoredAnimation", 0);
    }
}

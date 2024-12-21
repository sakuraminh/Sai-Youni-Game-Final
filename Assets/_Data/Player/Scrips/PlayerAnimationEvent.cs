using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvent : PlayerAbs
{
    public virtual void Attacking()
    {
        if (this.playerCtrl.PlayerSelect.EnemyChecks.Count > 0 && playerCtrl.PlayerDameReceive.IsDead == false)
        {
            this.playerCtrl.PlayerAttack.Attack(this.playerCtrl.PlayerSelect.EnemyChecks[0]);
            AudioManage.Instance.PlaySFX(AudioManage.Instance.playerFireFly);
        }
    }

    public virtual void FireReady()
    {
        AudioManage.Instance.PlaySFX(AudioManage.Instance.playerFIreReady);
    }

    public virtual void Run()
    {
        AudioManage.Instance.PlaySFX(AudioManage.Instance.playerRun);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEvent : PlayerAbs
{
    public virtual void Attacking()
    {
        if (this.playerCtrl.PlayerSelect.EnemyChecks.Count > 0)
        {
            this.playerCtrl.PlayerAttack.Attack(this.playerCtrl.PlayerSelect.EnemyChecks[0]);
        }
    }
}

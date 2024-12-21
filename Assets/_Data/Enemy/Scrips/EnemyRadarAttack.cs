using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadarAttack : Radar<PlayerCheck>
{
    public virtual bool PlayerInAttackRange()
    {
        return this.targetNearest != null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetRadarAttack : Radar<EnemyCheck>
{
    public virtual bool EnemyInAttackRange()
    {
        return this.targetNearest != null;
    }
}

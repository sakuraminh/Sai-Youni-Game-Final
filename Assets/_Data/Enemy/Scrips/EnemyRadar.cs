using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : Radar<PlayerCheck>
{
    public virtual bool PlayerInSightRange()
    {
        return this.targetNearest != null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : Despawner<Effect>
{
    protected override void Update()
    {
        base.Update();
        this.DespawnByTime();
    }
}

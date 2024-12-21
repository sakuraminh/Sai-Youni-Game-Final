using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenDamePoint : DameSender<PlayerDameReceive>
{
    protected override DameReceive SendDamage(Collider collider)
    {
        DameReceive damageReceiver = base.SendDamage(collider);
        if (damageReceiver == null) return null;
        this.gameObject.SetActive(false);
        return damageReceiver;
    }
}

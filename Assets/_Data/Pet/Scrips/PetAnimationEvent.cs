using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAnimationEvent : PetPrefabAbs
{
    public virtual void Attacking()
    {
        this.PetPrefabCtrl.PetAttack.Attack(this.PetPrefabCtrl.PetRadarAttack.TargetNearest);
    }
}

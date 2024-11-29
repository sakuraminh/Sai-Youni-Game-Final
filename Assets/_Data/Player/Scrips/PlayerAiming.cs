using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : PlayerAbs
{
    [SerializeField] protected float turnSpeet = 15;

    protected virtual void FixedUpdate()
    {
        this.CharacterAiming();
    }

    protected virtual void CharacterAiming()
    {
        float yawCamera = this.playerCtrl.MainCamera.transform.rotation.eulerAngles.y;

        transform.parent.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), this.turnSpeet * Time.fixedDeltaTime);
    }
}

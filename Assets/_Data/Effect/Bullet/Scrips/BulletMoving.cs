
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : EffectAbs
{
    public float speed = 30;

    protected virtual void Update()
    {
        this.Moving();
    }

    protected virtual void Moving()
    {
        transform.parent.Translate(Vector3.forward * this.speed * Time.deltaTime);
    }

}




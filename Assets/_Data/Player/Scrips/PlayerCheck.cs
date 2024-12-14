using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheck : MMonoBehaviour
{
    override protected void LoadComponents()
    {
        base.LoadComponents();
        this.SetLayer();
    }

    protected virtual void SetLayer()
    {
        gameObject.layer = LayerMask.NameToLayer("PlayerCheck");
    }
}

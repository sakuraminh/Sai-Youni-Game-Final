using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : Check
{
    protected Color defaultColor;
    public Color DefaultColor => this.defaultColor;
    override protected void LoadComponents()
    {
        base.LoadComponents();
        this.SetLayer();
    }

    protected virtual void SetLayer()
    {
        gameObject.layer = LayerMask.NameToLayer("EnemyCheck");
    }
}

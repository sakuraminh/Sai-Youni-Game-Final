using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCheck : Check
{
    protected Color defaultColor;
    public Color DefaultColor => this.defaultColor;
    override protected void LoadComponents()
    {
        base.LoadComponents();
        this.SetLayer();
        this.LoadDefaultColor();
    }

    protected virtual void SetLayer()
    {
        gameObject.layer = LayerMask.NameToLayer("ItemCheck");
    }
    protected virtual void LoadDefaultColor()
    {
        defaultColor = transform.parent.transform.Find("ItemModel").GetComponent<Renderer>().material.color;
    }
}

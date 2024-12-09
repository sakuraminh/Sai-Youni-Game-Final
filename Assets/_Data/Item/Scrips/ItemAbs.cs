using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAbs : MMonoBehaviour
{
    [SerializeField] protected ItemCrl itemCrl;
    public ItemCrl ItemCrl => this.itemCrl;
    #region LoadComponents
    override protected void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemCtrl();
    }

    protected void LoadItemCtrl()
    {
        if (this.itemCrl != null) return;
        this.itemCrl = transform.root.GetComponent<ItemCrl>();
        Debug.Log(transform.name + ": LoadItemCtrl", gameObject);
    }
    #endregion
}

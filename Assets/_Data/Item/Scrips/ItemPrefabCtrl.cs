using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPrefabCtrl : ItemAbs
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => this.itemDespawn;

    [SerializeField] protected ItemCheck itemCheck;
    public ItemCheck ItemCheck => this.itemCheck;

    #region LoadComponents
    override protected void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDespawn();
        this.LoadItemCheck();
    }
    protected void LoadItemCheck()
    {
        if (this.itemCheck != null) return;
        this.itemCheck = GetComponentInChildren<ItemCheck>();
        Debug.Log(transform.name + ": LoadItemCheck", gameObject);
    }
    protected void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ": LoadItemDespawn", gameObject);
    }
    #endregion
}

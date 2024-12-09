using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCtrl : MMonoBehaviour
{
    [SerializeField] protected InventoryManage inventoryManage;
    public InventoryManage InventoryManage => this.inventoryManage;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventoryManage();
    }

    protected virtual void LoadInventoryManage()
    {
        if (this.inventoryManage != null) return;
        this.inventoryManage = GetComponentInChildren<InventoryManage>();
        Debug.Log(transform.name + ": LoadInventoryManage", gameObject);
    }
}

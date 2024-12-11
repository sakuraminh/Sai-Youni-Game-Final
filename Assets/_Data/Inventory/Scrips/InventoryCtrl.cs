using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCtrl : MMonoBehaviour
{
    [SerializeField] protected InventoryManage inventoryManage;
    public InventoryManage InventoryManage => this.inventoryManage;

    [SerializeField] protected InventoryItems inventoryItems;
    public InventoryItems InventoryItems => this.inventoryItems;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventoryManage();
        this.LoadInventoryItems();
    }


    protected virtual void LoadInventoryItems()
    {
        if (this.inventoryItems != null) return;
        this.inventoryItems = GetComponentInChildren<InventoryItems>();
        Debug.Log(transform.name + ": LoadInventoryItems", gameObject);
    }
    protected virtual void LoadInventoryManage()
    {
        if (this.inventoryManage != null) return;
        this.inventoryManage = GetComponentInChildren<InventoryManage>();
        Debug.Log(transform.name + ": LoadInventoryManage", gameObject);
    }
}

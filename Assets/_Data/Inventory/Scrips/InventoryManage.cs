using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManage : MMonoBehaviour
{
    [SerializeField] protected List<InventoryBase> inventories = new();
    public List<InventoryBase> Inventories => this.inventories;

    [SerializeField] protected List<InventoryItem> itemProfile = new();
    public List<InventoryItem> ItemProfile => this.itemProfile;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInvemtories();
        this.LoadItemProfile();
    }

    protected virtual void LoadInvemtories()
    {
        if (this.inventories.Count > 0) return;
        this.inventories = new List<InventoryBase>(transform.GetComponentsInChildren<InventoryBase>());
        Debug.Log(transform.name + ": LoadInvemtories", gameObject);
    }
    protected virtual void LoadItemProfile()
    {
        if (this.itemProfile.Count > 0) return;
        this.itemProfile = new List<InventoryItem>(Resources.LoadAll<InventoryItem>("/"));
        Debug.Log(transform.name + ": LoadItemProfile", gameObject);
    }
}

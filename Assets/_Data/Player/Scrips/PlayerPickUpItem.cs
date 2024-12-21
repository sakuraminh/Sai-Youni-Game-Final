using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PlayerPickUpItem : PlayerAbs
{
    protected virtual void OnTriggerEnter(Collider item)
    {
        if (item.transform.parent == null) return;
        ItemCheck itemPickUp = item.GetComponent<ItemCheck>();
        if (itemPickUp == null) return;

        Item newItem = item.transform.parent.GetComponent<Item>();
        InventoryItem inventoryItem = this.GetItemByPrefab(newItem);

        this.PickingItem(inventoryItem, 1);
        CallDesspawn(item);
    }

    protected virtual InventoryItem GetItemByPrefab(Item item)
    {
        InventoryItem inventoryItem = playerCtrl.GameCtrl.InventoryCtrl.InventoryManage.GetItemByName(item.GetName());
        return inventoryItem;
    }

    protected void PickingItem(InventoryItem item, int count)
    {
        playerCtrl.GameCtrl.InventoryCtrl.InventoryManage.Inventories[0].AddItem(item, count);
    }

    protected virtual void CallDesspawn(Collider item)
    {
        item.transform.parent.GetComponent<ItemPrefabCtrl>().ItemDespawn.DoDespawn();
    }
}

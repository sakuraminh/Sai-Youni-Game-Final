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
        this.PickingItem();
        CallDesspawn(item);
    }

    protected void PickingItem()
    {
        playerCtrl.GameCtrl.InventoryCtrl.InventoryManage.Inventories[0].AddItem(playerCtrl.GameCtrl.InventoryCtrl.InventoryManage.ItemProfile[0], 10);
    }

    protected virtual void CallDesspawn(Collider item)
    {
        item.transform.parent.GetComponent<ItemPrefabCtrl>().ItemDespawn.DoDespawn();
    }
}

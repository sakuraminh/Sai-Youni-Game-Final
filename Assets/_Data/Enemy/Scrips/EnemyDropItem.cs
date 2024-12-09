using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropItem : EnemyAbs
{
    public virtual void ItemDroping(InventoryItem itemName, Vector3 pos)
    {
        Item prefab = EnemyCtrl.GameCtrl.ItemCrl.ItemPrefab.GetPrefabByName(itemName.Name);
        if (prefab == null)
        {
            Debug.Log("Item Not Foud");
            return;
        }
        Item newItem = EnemyCtrl.GameCtrl.ItemCrl.ItemSpawner.Spawn(prefab, pos);
        newItem.gameObject.SetActive(true);
    }
}

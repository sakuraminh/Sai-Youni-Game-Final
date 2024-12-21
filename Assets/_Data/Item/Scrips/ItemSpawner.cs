using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner<Item>
{
    [SerializeField] protected ItemCrl itemCrl;
    public ItemCrl ItemCrl => this.itemCrl;


    public virtual void ItemSpawn(InventoryItem itemName, Vector3 pos)
    {
        Item prefab = ItemCrl.ItemPrefab.GetPrefabByName(itemName.Name);
        if (prefab == null)
        {
            Debug.Log("Item Not Foud");
            return;
        }
        Item newItem = this.Spawn(prefab, pos);
        newItem.gameObject.SetActive(true);
    }
    #region LoadComponents
    override protected void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemCrl();
    }

    protected virtual void LoadItemCrl()
    {
        if (this.itemCrl != null) return;
        this.itemCrl = transform.parent.GetComponent<ItemCrl>();
        Debug.Log(transform.name + ": LoadItemCrl", gameObject);
    }
    #endregion
}

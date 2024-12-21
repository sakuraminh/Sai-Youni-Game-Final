using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCrl : MMonoBehaviour
{
    [SerializeField] protected ItemSpawner itemSpawner;
    public ItemSpawner ItemSpawner => this.itemSpawner;

    [SerializeField] protected ItemPrefab itemPrefab;
    public ItemPrefab ItemPrefab => this.itemPrefab;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemSpawner();
        this.LoadItemPrefab();
    }

    protected virtual void LoadItemPrefab()
    {
        if (this.itemPrefab != null) return;
        this.itemPrefab = GetComponentInChildren<ItemPrefab>();
        Debug.Log(transform.name + ": LoadItemPrefab", gameObject);
    }

    protected virtual void LoadItemSpawner()
    {
        if (this.itemSpawner != null) return;
        this.itemSpawner = this.GetComponentInChildren<ItemSpawner>();
        Debug.Log(transform.name + ": LoadItemSpawner", gameObject);
    }
}

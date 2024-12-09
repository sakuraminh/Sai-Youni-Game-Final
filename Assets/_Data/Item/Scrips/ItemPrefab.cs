using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPrefab : PoolPrefabs<Item>
{
    public virtual Item GetPrefabByName(string name)
    {
        foreach (Item prefab in this.Prefabs)
        {
            if (prefab.name != name) continue;
            Debug.Log("Item Found :" + prefab.name);
            return prefab;
        }
        return null;
    }
}

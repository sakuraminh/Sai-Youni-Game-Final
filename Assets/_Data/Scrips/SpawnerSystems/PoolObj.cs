using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolObj : MMonoBehaviour
{
    [SerializeField] protected DespawnBase despawn;
    public DespawnBase Despawn => despawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawn();
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<DespawnBase>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }
    public abstract string GetName();
}

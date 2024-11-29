using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawner<T> : DespawnBase where T : PoolObj
{
    [SerializeField] protected T parent;
    [SerializeField] protected Spawner<T> spawner;
    [SerializeField] protected bool isDespawnByTime = true;
    [SerializeField] protected float timeLife = 7;
    [SerializeField] protected float currentTime = 7;


    protected virtual void Update()
    {
        //Override
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadParent();
        this.LoadSpawn();
    }
    protected virtual void LoadParent()
    {
        if (this.parent != null) return;

        this.parent = transform.parent.GetComponent<T>();
        Debug.Log(transform.name + ": LoadParent", gameObject);
    }

    protected virtual void LoadSpawn()
    {
        if (this.spawner != null) return;

        this.spawner = GameObject.FindAnyObjectByType<Spawner<T>>();
        Debug.Log(transform.name + ": LoadSpawn", gameObject);

    }
    protected virtual void DespawnByTime()
    {
        if (!this.isDespawnByTime) return;

        this.currentTime -= Time.fixedDeltaTime;
        if (this.currentTime > 0) return;

        this.DoDespawn();
        this.currentTime = this.timeLife;
    }

    public override void DoDespawn()
    {
        this.spawner.Despawn(this.parent);
    }
}

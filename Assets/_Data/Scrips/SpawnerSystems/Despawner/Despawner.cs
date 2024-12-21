using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawner<T> : DespawnBase where T : PoolObj
{
    [SerializeField] protected T parent;
    [SerializeField] protected Spawner<T> spawner;

    [SerializeField] protected float distanceToDespawn = 10;
    [SerializeField] protected float distanceDespawn = 10;
    [SerializeField] protected float timeLife = 5;
    [SerializeField] protected float currentTime = 5;

    [SerializeField] protected bool isDespawnByTime = true;
    [SerializeField] protected bool isDespawnByDistance = true;

    protected virtual void Update()
    {
        //
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
    public abstract void DespawnByDistance();

    public override void DoDespawn()
    {
        //Debug.Log("Despawn: " + this.parent, gameObject);
        this.spawner.Despawn(this.parent);
    }
}

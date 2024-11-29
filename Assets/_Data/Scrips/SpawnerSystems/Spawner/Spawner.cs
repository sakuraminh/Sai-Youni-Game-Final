using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Spawner<T> : MMonoBehaviour where T : PoolObj
{
    [SerializeField] protected int spawnCount = 0;
    [SerializeField] protected List<T> inPoolObjs = new();
    [SerializeField] protected Transform hold;

    public virtual T Spawn(T prefab)
    {
        T newObj = this.GetObjFromPool(prefab);
        if (newObj == null)
        {
            newObj = Instantiate(prefab);
            this.spawnCount++;
            this.UpdateName(prefab.transform, newObj.transform);
            newObj.transform.parent = this.hold;

        }
        newObj.transform.parent = this.hold;
        return newObj;
    }
    public virtual T Spawn(T prefab, Vector3 pos)
    {
        T newObj = this.Spawn(prefab);
        newObj.transform.position = pos;

        return newObj;
    }

    public virtual T Spawn(T prefab, Quaternion rot)
    {
        T newObj = this.Spawn(prefab);
        newObj.transform.rotation = rot;

        return newObj;
    }


    public virtual T Spawn(T prefab, Vector3 pos, Quaternion rot)
    {
        T newObj = Spawn(prefab);
        newObj.transform.position = pos;
        newObj.transform.rotation = rot;

        return newObj;
    }

    public virtual void Despawn(T obj)
    {
        if (obj is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(false);
            this.AddObjectToPool(obj);
        }
    }

    protected virtual T GetObjFromPool(T prefab)
    {
        foreach (T inPoolObj in this.inPoolObjs)
        {
            if (prefab.GetName() == inPoolObj.GetName())
            {
                this.RemoveObjFromPool(inPoolObj);
                return inPoolObj;
            }
        }
        return null;
    }
    protected virtual void RemoveObjFromPool(T obj)
    {
        this.inPoolObjs.Remove(obj);
    }

    protected virtual void AddObjectToPool(T obj)
    {
        this.inPoolObjs.Add(obj);
    }

    protected virtual void UpdateName(Transform prefab, Transform newObj)
    {
        newObj.name = prefab.name + "_" + this.spawnCount;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHold();
    }

    private void LoadHold()
    {
        if (this.hold != null) return;
        this.hold = transform.Find("Hold");
        if (this.hold == null) this.hold = new GameObject("Hold").transform;
        hold.transform.parent = this.transform;
        Debug.Log(transform.name + " LoadHold", gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class DameSender<T> : MMonoBehaviour where T : DameReceive
{
    [SerializeField] protected int dame = 2;
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected Collider _collider;

    protected virtual void OnTriggerEnter(Collider collider)
    {
        this.SendDamage(collider);
    }

    protected virtual DameReceive SendDamage(Collider collider)
    {
        T damageReceiver = collider.GetComponent<T>();

        if (damageReceiver == null) return null;

        damageReceiver.Receive(this.dame);
        return damageReceiver;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
        this.LoadTriggerCollider();
    }

    protected virtual void LoadRigidbody()
    {
        if (rb != null) return;
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        Debug.Log(transform.name + " :LoadRigdbody", gameObject);
    }

    protected virtual void LoadTriggerCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<Collider>();
        this._collider.isTrigger = true;
        Debug.Log(transform.name + ": LoadTriggerCollider", gameObject);
    }
}

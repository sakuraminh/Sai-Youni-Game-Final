using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class DameReceive : MMonoBehaviour
{
    [SerializeField] protected CapsuleCollider capsuleCollider;

    [SerializeField] protected bool isImmortal = false;
    [SerializeField] protected bool isHit = false;
    [SerializeField] protected bool isDead = false;
    public bool IsDead => this.isDead;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }
    protected virtual void OnTriggerEnter(Collider collider)
    {
        //Override
    }
    protected abstract void OnHurt();
    protected abstract void OnDead();
    public abstract void Receive(int dame);
    public abstract bool SetIsDead();
    protected abstract void Reborn();
    #region LoadComponents
    override protected void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCapsuleCollider();
    }
    protected abstract void LoadCapsuleCollider();
    #endregion
}

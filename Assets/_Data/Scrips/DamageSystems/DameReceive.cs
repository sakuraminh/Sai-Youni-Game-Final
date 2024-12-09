using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class DameReceive : MMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => this.enemyCtrl;

    [SerializeField] protected EnemyPrefabCtrl prefabCtrl;
    public EnemyPrefabCtrl PrefabCtrl => this.prefabCtrl;

    [SerializeField] protected CapsuleCollider capsuleCollider;

    [SerializeField] protected int currenHp = 10;
    [SerializeField] protected int maxHp = 10;

    [SerializeField] protected bool isImmortal = false;
    [SerializeField] protected bool isHit = false;
    [SerializeField] protected bool isDead = false;
    public bool IsDead => this.isDead;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }
    protected abstract void OnHurt();
    protected abstract void OnDead();

    protected virtual void OnTriggerEnter(Collider collider)
    {
        //Override
    }
    public virtual void Receive(int dame, DameSender dameSender)
    {
        if (!isImmortal) this.currenHp -= dame;
        if (currenHp < 0) currenHp = 0;

        if (this.SetIsDead()) this.OnDead();
        else this.OnHurt();
    }

    //protected virtual void ActAfterDead()
    //{
    //    if (this.SetIsDead()) this.OnDead();
    //    else this.OnHurt();
    //}

    public virtual bool SetIsDead()
    {
        return this.isDead = this.currenHp <= 0;
    }
    protected virtual void Reborn()
    {
        this.currenHp = this.maxHp;
    }

    override protected void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCapsuleCollider();
        this.LoadEnemyCtrl();
        this.LoadEnemyPrefabCtrl();
    }
    protected abstract void LoadCapsuleCollider();

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.root.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected virtual void LoadEnemyPrefabCtrl()
    {
        if (this.prefabCtrl != null) return;
        this.prefabCtrl = transform.parent.GetComponent<EnemyPrefabCtrl>();
        Debug.Log(transform.name + ": LoadEnemyPrefabCtrl", gameObject);
    }
}

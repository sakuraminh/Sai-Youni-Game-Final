using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : PoolObj
{
    [SerializeField] protected EnemyPrefabCtrl enemyPrefabCtrl;
    public EnemyPrefabCtrl EnemyPrefabCtrl => this.enemyPrefabCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyPrefabCtrl();
    }

    protected virtual void LoadEnemyPrefabCtrl()
    {
        if (this.enemyPrefabCtrl != null) return;
        this.enemyPrefabCtrl = this.GetComponentInChildren<EnemyPrefabCtrl>();
        Debug.Log(transform.name + ": LoadEnemyPrefabCtrl", gameObject);
    }
}

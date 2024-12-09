using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabCtrl : MMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => this.enemyCtrl;

    [SerializeField] protected Enemy enemy;
    public Enemy Enemy => enemy;

    [SerializeField] protected EnemyMoving enemyMoving;
    public EnemyMoving EnemyMoving => enemyMoving;

    [SerializeField] protected EnemyCheck enemyCheck;
    public EnemyCheck EnemyCheck => enemyCheck;

    [SerializeField] protected EnemyDropItem enemyDropItem;
    public EnemyDropItem EnemyDropItem => enemyDropItem;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyMoving();
        this.LoadEnemy();
        this.LoadEnemyCtrl();
        this.LoadEnemyCheck();
        this.LoadEnemyDropItem();
    }

    protected virtual void LoadEnemyDropItem()
    {
        if (this.enemyDropItem != null) return;
        this.enemyDropItem = this.GetComponentInChildren<EnemyDropItem>();
        Debug.Log(transform.name + ": LoadEnemyDropItem", gameObject);
    }

    protected virtual void LoadEnemyCheck()
    {
        if (this.enemyCheck != null) return;
        this.enemyCheck = this.GetComponentInChildren<EnemyCheck>();
        Debug.Log(transform.name + ": LoadEnemyCheck", gameObject);
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = this.GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected virtual void LoadEnemy()
    {
        if (this.enemy != null) return;
        this.enemy = this.GetComponent<Enemy>();
        Debug.Log(transform.name + ": LoadEnemy", gameObject);
    }
    protected virtual void LoadEnemyMoving()
    {
        if (this.enemyMoving != null) return;
        this.enemyMoving = this.GetComponentInChildren<EnemyMoving>();
        Debug.Log(transform.name + ": LoadEnemyMoving", gameObject);
    }
}

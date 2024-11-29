using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabCtrl : MMonoBehaviour
{
    [SerializeField] protected EnemyMoving enemyMoving;
    public EnemyMoving EnemyMoving => enemyMoving;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyMoving();
    }

    protected virtual void LoadEnemyMoving()
    {
        if (this.enemyMoving != null) return;
        this.enemyMoving = this.GetComponentInChildren<EnemyMoving>();
        Debug.Log(transform.name + ": LoadEnemyMoving", gameObject);
    }
}

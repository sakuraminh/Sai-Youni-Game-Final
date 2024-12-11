using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabAbs : MMonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => this.enemyCtrl;

    [SerializeField] protected EnemyPrefabCtrl enemyPrefabCtrl;
    public EnemyPrefabCtrl EnemyPrefabCtrl => this.enemyPrefabCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadEnemyPrefabCtrl();
    }

    protected virtual void LoadEnemyPrefabCtrl()
    {
        if (this.enemyPrefabCtrl != null) return;
        this.enemyPrefabCtrl = transform.parent.GetComponent<EnemyPrefabCtrl>();
        //Debug.Log(transform.name + ": LoadEnemyPrefabCtrl", gameObject);
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.root.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
}

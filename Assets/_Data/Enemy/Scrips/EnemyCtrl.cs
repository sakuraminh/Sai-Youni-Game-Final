using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => this.playerCtrl;

    [SerializeField] protected EnemyPrefab enemyPrefab;
    public EnemyPrefab EnemyPrefab => this.enemyPrefab;

    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => this.enemySpawner;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadenEmyPrefab();
        this.LoadEnemySpawner();
        this.LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
    protected virtual void LoadenEmyPrefab()
    {
        if (this.enemyPrefab != null) return;
        this.enemyPrefab = GetComponentInChildren<EnemyPrefab>();
        Debug.Log(transform.name + ": LoadenEmyPrefab", gameObject);
    }

    protected virtual void LoadEnemySpawner()
    {
        if (this.enemySpawner != null) return;
        this.enemySpawner = GetComponentInChildren<EnemySpawner>();
        Debug.Log(transform.name + ": LoadEnemySpawner", gameObject);
    }
}

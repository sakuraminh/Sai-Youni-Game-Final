using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MMonoBehaviour
{
    [SerializeField] protected EnemyPrefab enemyPrefab;
    public EnemyPrefab EnemyPrefab => this.enemyPrefab;

    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => this.enemySpawner;

    [SerializeField] protected EnemySpawnAreasList enemySpawnAreasList;
    public EnemySpawnAreasList EnemySpawnAreasList => this.enemySpawnAreasList;

    [SerializeField] protected GameCtrl gameCtrl;
    public GameCtrl GameCtrl => this.gameCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadenEmyPrefab();
        this.LoadEnemySpawner();
        this.LoadEnemySpawnAreasList();
        this.LoadGameCtrl();
    }

    protected virtual void LoadGameCtrl()
    {
        if (this.gameCtrl != null) return;
        this.gameCtrl = GameObject.Find("GameCtrl").GetComponent<GameCtrl>();
        Debug.Log(transform.name + ": LoadGameCtrl", gameObject);
    }

    protected virtual void LoadEnemySpawnAreasList()
    {
        if (this.enemySpawnAreasList != null) return;
        this.enemySpawnAreasList = GetComponentInChildren<EnemySpawnAreasList>();
        Debug.Log(transform.name + ": LoadEnemySpawnAreasList", gameObject);
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

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

    [SerializeField] protected Helper helper;
    public Helper Helper => this.helper;

    [SerializeField] protected EnemySpawnAreasList enemySpawnAreasList;
    public EnemySpawnAreasList EnemySpawnAreasList => this.enemySpawnAreasList;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadenEmyPrefab();
        this.LoadEnemySpawner();
        this.LoadPlayerCtrl();
        this.LoadHelper();
        this.LoadEnemySpawnAreasList();
    }

    protected virtual void LoadEnemySpawnAreasList()
    {
        if (this.enemySpawnAreasList != null) return;
        this.enemySpawnAreasList = GetComponentInChildren<EnemySpawnAreasList>();
        Debug.Log(transform.name + ": LoadEnemySpawnAreasList", gameObject);
    }

    protected virtual void LoadHelper()
    {
        if (this.helper != null) return;
        this.helper = GameObject.Find("Helper").GetComponent<Helper>();
        Debug.Log(transform.name + ": LoadHelper", gameObject);
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

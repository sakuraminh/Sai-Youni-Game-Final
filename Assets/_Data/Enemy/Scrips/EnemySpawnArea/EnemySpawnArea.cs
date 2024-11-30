using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemySpawnArea : EnemyAbs
{
    [SerializeField] protected List<Enemy> enemies = new();
    public List<Enemy> Enemies => enemies;

    [SerializeField] protected float spawnSpeed = 0.1f;
    [SerializeField] protected int maxSpawn = 10;

    [SerializeField] protected float range = 100f;
    [SerializeField] protected float validRange = 5f;

    protected override void Start()
    {
        base.Start();
        this.Spawning();
    }

    public abstract string AreaName();
    public abstract Enemy GetEnemyPrefabByName();

    protected virtual void Spawning()
    {
        Invoke(nameof(Spawning), 1f);
        if (this.enemies.Count >= 10) return;
        Vector3 point;

        if (HelperSingleton.Instance.RandomPointOnNavMesh.RandomPoint(transform.position, range, validRange, out point))
        {
            Enemy newEnemy = this.EnemyCtrl.EnemySpawner.Spawn(this.GetEnemyPrefabByName(), point);
            newEnemy.EnemyPrefabCtrl.EnemyMoving.SetSpawnAreaPos(point);
            newEnemy.gameObject.SetActive(true);
            this.enemies.Add(newEnemy);
        }
    }
}

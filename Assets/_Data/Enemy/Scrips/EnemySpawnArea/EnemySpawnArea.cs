using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemySpawnArea : EnemyAbs
{
    [SerializeField] protected List<Enemy> enemies = new();
    public List<Enemy> Enemies => enemies;

    [SerializeField] protected float range = 100f;
    [SerializeField] protected int maxSpawn = 10;
    [SerializeField] protected float spawnSpeed = 0.1f;

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
        if (this.enemies.Count > 10) return;

        Vector3 result;

        if (this.RandomPoint(out result))
        {
            Enemy newEnemy = this.EnemyCtrl.EnemySpawner.Spawn(this.GetEnemyPrefabByName(), result);
            newEnemy.EnemyPrefabCtrl.EnemyMoving.spawnArea = result;
            newEnemy.gameObject.SetActive(true);
            this.enemies.Add(newEnemy);
        }
    }

    public virtual bool RandomPoint(out Vector3 result)
    {
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * this.range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 5.0f, NavMesh.AllAreas))
        {
            result = hit.position;

            return true;
        }
        this.RandomPoint(out result);
        return false;
    }
}

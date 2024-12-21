using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea2 : EnemySpawnArea
{
    [SerializeField] protected string enemyName = "EnemyTest2";
    public override string AreaName()
    {
        return "Spawn Area 2";
    }

    public override Enemy GetEnemyPrefabByName()
    {
        foreach (Enemy enemy in EnemyCtrl.EnemyPrefab.Prefabs)
        {
            if (enemy.GetName() == enemyName)
            {
                return enemy;
            }
        }
        return null;
    }
}

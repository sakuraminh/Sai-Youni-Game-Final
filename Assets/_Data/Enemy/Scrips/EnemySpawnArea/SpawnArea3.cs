using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea3 : EnemySpawnArea
{
    [SerializeField] protected string enemyName = "EnemyTest3";
    public override string AreaName()
    {
        return "Spawn Area 3";
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

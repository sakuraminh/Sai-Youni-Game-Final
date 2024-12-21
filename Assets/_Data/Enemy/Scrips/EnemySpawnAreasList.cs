using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnAreasList : MMonoBehaviour
{
    [SerializeField] protected List<EnemySpawnArea> enemySpawnAreas = new();
    public List<EnemySpawnArea> EnemySpawnAreas => this.enemySpawnAreas;
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawnAreas();
    }

    protected virtual void LoadEnemySpawnAreas()
    {
        if (this.enemySpawnAreas.Count > 0) return;
        foreach (Transform chil in transform)
        {
            this.enemySpawnAreas.Add(chil.GetComponent<EnemySpawnArea>());
        }
        Debug.Log(transform.name + ": LoadEnemySpawnAreas", gameObject);
    }
    #endregion
}

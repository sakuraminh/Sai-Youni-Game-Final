using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDameReceive : DameReceive
{
    protected override void OnTriggerEnter(Collider collider)
    {
        this.OnAnimation(collider);
    }
    protected override void OnDead()
    {
        this.CallDespawn();
        this.capsuleCollider.enabled = false;
        PrefabCtrl.EnemyCtrl.GameCtrl.ItemCrl.ItemSpawner.ItemSpawn(this.enemyCtrl.GameCtrl.InventoryCtrl.InventoryManage.ItemProfile[0], transform.parent.position);
    }
    protected override void OnHurt()
    {
        //
    }
    protected virtual void OnAnimation(Collider collider) //sử dụng OnTriggerStay và kiểm tra activeSelf
    {
    }

    protected virtual void SetHitFalse()
    {
    }
    protected virtual bool SetHit(Collider collider)
    {
        DameSender sender = collider.GetComponent<DameSender>();
        return this.isHit = sender != null;
    }
    protected virtual void CallDespawn()
    {
        this.RemoveTargetCheckFromEnemySpawnAreas(this.prefabCtrl.EnemyCheck);
        this.RemoveTargetCheckFromPlayer(this.prefabCtrl.EnemyCheck);
        this.prefabCtrl.Enemy.Despawn.DoDespawn();

    }
    protected virtual void RemoveTargetCheckFromPlayer(EnemyCheck targetCheck)
    {
        this.prefabCtrl.EnemyCtrl.GameCtrl.PlayerCtrl.PlayerRadar.TargetChecks.Remove(targetCheck);
    }
    protected virtual void RemoveTargetCheckFromEnemySpawnAreas(EnemyCheck targetCheck)
    {
        foreach (EnemySpawnArea enemySpawnArea in this.prefabCtrl.EnemyCtrl.EnemySpawnAreasList.EnemySpawnAreas)
        {
            if (enemySpawnArea.GetEnemyPrefabByName().GetName() != targetCheck.transform.parent.GetComponent<Enemy>().GetName()) continue;

            enemySpawnArea.Enemies.Remove(targetCheck.transform.parent.GetComponent<Enemy>());
        }
    }
    protected override void Reborn()
    {
        base.Reborn();
        this.capsuleCollider.enabled = true;
    }
    #region LoadComponents
    protected override void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    #endregion
}

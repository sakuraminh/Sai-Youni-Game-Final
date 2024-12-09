using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDameReceive : DameReceive
{
    protected override void OnDead()
    {
        this.CallDespawn();
        this.capsuleCollider.enabled = false;

        PrefabCtrl.EnemyCtrl.GameCtrl.ItemCrl.ItemSpawner.ItemSpawn(this.enemyCtrl.GameCtrl.InventoryCtrl.InventoryManage.ItemProfile[0], transform.parent.position);

        //this.prefabCtrl.Animator.SetBool("isDead", prefabCtrl.EnemyDameReceive.IsDead);
        //Invoke(nameof(CallDespawn), 4f);
    }
    protected override void OnHurt()
    {
        //
    }
    protected override void OnTriggerEnter(Collider collider)
    {
        this.OnAnimation(collider);
    }
    protected void OnAnimation(Collider collider) //sử dụng OnTriggerStay và kiểm tra activeSelf
    {
    }

    protected void SetHitFalse()
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

    protected override void Reborn()
    {
        base.Reborn();
        this.capsuleCollider.enabled = true;
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

    protected override void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }


}

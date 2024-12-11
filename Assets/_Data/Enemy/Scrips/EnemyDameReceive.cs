using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDameReceive : DameReceive
{
    protected override void OnTriggerEnter(Collider collider)
    {
        this.OnAnimation(collider);
    }
    public override void Receive(int dame, DameSender dameSender)
    {
        if (!isImmortal) this.currenHp -= dame;
        if (this.currenHp < 0) this.currenHp = 0;

        this.prefabCtrl.EnemyHPUI.UpdateSlider();


        if (this.SetIsDead()) this.OnDead();
        else this.OnHurt();
    }
    protected override void OnDead()
    {
        this.CallDespawn();
        //this.prefabCtrl.EnemyHPUI.UpdateSlider();
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
        this.prefabCtrl.Enemy.Despawn.DoDespawn();
        this.RemoveTargetCheckFromEnemySpawnAreas(this.prefabCtrl.EnemyCheck);
        this.RemoveTargetCheckFromPlayer(this.prefabCtrl.EnemyCheck);
        this.RemoveTargetCheckFromPlayerSelect(this.prefabCtrl.EnemyCheck);
    }
    protected virtual void RemoveTargetCheckFromPlayer(EnemyCheck targetCheck)
    {
        this.prefabCtrl.EnemyCtrl.GameCtrl.PlayerCtrl.PlayerRadar.TargetChecks.Remove(targetCheck);
    }

    protected virtual void RemoveTargetCheckFromPlayerSelect(EnemyCheck targetCheck)
    {
        targetCheck.transform.parent.transform.Find("EnemyModel").GetComponent<Renderer>().material.color = targetCheck.DefaultColor;
        this.prefabCtrl.EnemyCtrl.GameCtrl.PlayerCtrl.PlayerSelect.EnemyChecks.Remove(targetCheck);
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
        //this.prefabCtrl.EnemyHPUI.UpdateSlider();
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

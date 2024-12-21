using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDameReceive : DameReceive
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => this.enemyCtrl;

    [SerializeField] protected EnemyPrefabCtrl prefabCtrl;
    public EnemyPrefabCtrl PrefabCtrl => this.prefabCtrl;

    [SerializeField] protected int currenHp = 10;
    public int CurrentHp => this.currenHp;

    [SerializeField] protected int maxHp = 10;
    public int MaxHp => this.maxHp;

    //protected override void OnTriggerEnter(Collider collider)
    //{
    //    this.OnAnimation(collider);
    //}
    public override void Receive(int dame)
    {
        if (!isImmortal) this.currenHp -= dame;
        if (this.currenHp < 0) this.currenHp = 0;

        if (this.isDead != true)
        {
            this.prefabCtrl.Animator.SetTrigger("isHit");
            AudioManage.Instance.PlaySFX(AudioManage.Instance.enemyHit);
        }

        this.prefabCtrl.EnemyHPUI.UpdateSlider();


        if (this.SetIsDead()) this.OnDead();
        else this.OnHurt();
    }
    public override bool SetIsDead()
    {
        return this.isDead = this.currenHp <= 0;
    }
    protected override void Reborn()
    {
        this.currenHp = this.maxHp;
        this.capsuleCollider.enabled = true;
    }
    protected override void OnDead()
    {

        this.capsuleCollider.enabled = false;
        this.RemoveFromLists();
        this.RanDomCountSpawn();

        this.prefabCtrl.Animator.SetBool("isMoving", !this.isDead);
        this.prefabCtrl.Animator.SetBool("isDead", this.isDead);
        AudioManage.Instance.PlaySFX(AudioManage.Instance.enemyDie);

        Invoke(nameof(this.CallDespawn), 5f);
    }

    protected virtual void RanDomCountSpawn()
    {
        int ranDom = Random.Range(0, 11);

        for (int i = 0; i < ranDom; i++)
        {
            this.prefabCtrl.EnemyCtrl.GameCtrl.ItemCrl.ItemSpawner.ItemSpawn(this.RanDomItem(), transform.parent.position);
        }
    }

    protected virtual InventoryItem RanDomItem()
    {
        int ranDom = Random.Range(0, 2);
        InventoryItem newItem = this.enemyCtrl.GameCtrl.InventoryCtrl.InventoryManage.ItemProfile[ranDom];
        return newItem;

    }
    protected override void OnHurt()
    {
        //
    }
    //protected virtual void OnAnimation(Collider collider) //sử dụng OnTriggerStay và kiểm tra activeSelf
    //{
    //}

    protected virtual void RemoveFromLists()
    {
        this.RemoveTargetCheckFromEnemySpawnAreas(this.prefabCtrl.EnemyCheck);
        this.RemoveTargetCheckFromPlayer(this.prefabCtrl.EnemyCheck);
        this.RemoveTargetCheckFromPlayerSelect(this.prefabCtrl.EnemyCheck);
        this.RemoveTargetCheckFromPet(this.prefabCtrl.EnemyCheck);
    }
    protected virtual void CallDespawn()
    {
        this.prefabCtrl.Enemy.Despawn.DoDespawn();
    }

    protected virtual void RemoveTargetCheckFromPet(EnemyCheck targetCheck)
    {
        this.prefabCtrl.EnemyCtrl.GameCtrl.PetCtrl.PetRadarAttack.TargetChecks.Remove(targetCheck);
    }
    protected virtual void RemoveTargetCheckFromPlayer(EnemyCheck targetCheck)
    {
        this.prefabCtrl.EnemyCtrl.GameCtrl.PlayerCtrl.PlayerRadar.TargetChecks.Remove(targetCheck);
    }

    protected virtual void RemoveTargetCheckFromPlayerSelect(EnemyCheck targetCheck)
    {
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
    #region LoadComponents

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadEnemyPrefabCtrl();
    }
    protected override void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.root.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected virtual void LoadEnemyPrefabCtrl()
    {
        if (this.prefabCtrl != null) return;
        this.prefabCtrl = transform.parent.GetComponent<EnemyPrefabCtrl>();
        Debug.Log(transform.name + ": LoadEnemyPrefabCtrl", gameObject);
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDameReceive : DameReceive
{
    [SerializeField] protected EnemyPrefabCtrl prefabCtrl;
    public EnemyPrefabCtrl PrefabCtrl => this.prefabCtrl;

    protected override void OnDead()
    {
        this.CallDespawn();
        this.capsuleCollider.enabled = false;

        //this.prefabCtrl.Animator.SetBool("isDead", prefabCtrl.EnemyDameReceive.IsDead);
        //Invoke(nameof(CallDespawn), 4f);

        //InventoriesManager.Instance.AddItem(ItemCode.Gold, 1);
        //InventoriesManager.Instance.AddItem(ItemCode.PlayerExp, 1);
    }
    protected override void OnHurt()
    {
        //
    }
    protected override void OnTriggerEnter(Collider collider)
    {
        this.OnAnimation(collider);
    }
    protected void OnAnimation(Collider collider)
    {
        //this.SetHit(collider);
        //this.prefabCtrl.Animator.SetBool("isHit", this.SetHit(collider));
        //this.prefabCtrl.Agent.speed = 0.1f;
        //Invoke(nameof(SetHitFalse), 0.2f);
    }

    protected void SetHitFalse()
    {
        //this.isHit = false;
        //this.prefabCtrl.Animator.SetBool("isHit", this.isHit);
        //this.prefabCtrl.Agent.speed = 2;
    }
    protected virtual bool SetHit(Collider collider)
    {
        DameSender sender = collider.GetComponent<DameSender>();
        return this.isHit = sender != null;
    }
    protected virtual void CallDespawn()
    {
        this.prefabCtrl.Enemy.Despawn.DoDespawn();
        this.RemoveTargetChecks(this.prefabCtrl.EnemyCheck);
    }

    protected override void Reborn()
    {
        base.Reborn();
        this.capsuleCollider.enabled = true;
    }

    protected virtual void RemoveTargetChecks(EnemyCheck targetCheck)
    {
        this.prefabCtrl.EnemyCtrl.PlayerCtrl.PlayerRadar.TargetChecks.Remove(targetCheck);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyPrefabCtrl();
        this.LoadCapsuleCollider();
    }
    protected virtual void LoadEnemyPrefabCtrl()
    {
        if (this.prefabCtrl != null) return;
        this.prefabCtrl = transform.parent.GetComponent<EnemyPrefabCtrl>();
        Debug.Log(transform.name + ": LoadEnemyPrefabCtrl", gameObject);
    }
    protected virtual void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }


}

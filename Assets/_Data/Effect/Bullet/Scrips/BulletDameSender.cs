using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class BulletDameSender : DameSender<EnemyDameReceive>
{

    [SerializeField] protected EffectCtrl effectCtrl;
    public EffectCtrl EffectCtrl => this.effectCtrl;


    [SerializeField] protected int count = 0;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Effect effectDespawn;
    public Effect Effect => this.effectDespawn;

    protected override DameReceive SendDamage(Collider collider)
    {
        DameReceive damageReceiver = base.SendDamage(collider);
        if (damageReceiver == null) return null;
        AudioManage.Instance.PlaySFX(AudioManage.Instance.playerFireHit);
        AudioManage.Instance.PlaySFX(AudioManage.Instance.enemyHit);
        this.EffectHitSpawn(collider);
        this.effectDespawn.Despawn.DoDespawn();
        return damageReceiver;
    }

    protected virtual void EffectHitSpawn(Collider collider)
    {
        Vector3 pos = collider.ClosestPoint(transform.position);
        Effect effectHit1 = effectCtrl.EffectPrefab.GetByName("EffectHit1");
        Effect newEffect = effectCtrl.EffectSpawner.Spawn(effectHit1, pos);
        newEffect.gameObject.SetActive(true);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawn();
        this.LoadEffectCtrl();
    }

    protected virtual void LoadDespawn()
    {
        if (this.effectDespawn != null) return;
        this.effectDespawn = transform.parent.GetComponentInChildren<Effect>();
        Debug.Log(transform.name + ": LoadDespawn", gameObject);
    }
    protected override void LoadTriggerCollider()
    {
        if (this._collider != null) return;
        this._collider = GetComponent<Collider>();
        this._collider.isTrigger = true;
        this.sphereCollider = (SphereCollider)this._collider;
        sphereCollider.radius = 0.5f;
        Debug.Log(transform.name + ": LoadTriggerCollider", gameObject);
    }
    protected virtual void LoadEffectCtrl()
    {
        if (this.effectCtrl != null) return;
        this.effectCtrl = transform.root.GetComponent<EffectCtrl>();
        Debug.Log(transform.name + ": LoadEffectCtrl", gameObject);
    }
}

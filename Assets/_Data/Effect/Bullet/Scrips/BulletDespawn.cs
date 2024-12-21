using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : Despawner<Effect>
{
    [SerializeField] protected EffectCtrl effectCtrl;
    public EffectCtrl EffectCtrl => this.effectCtrl;

    protected override void Update()
    {
        base.Update();
        this.DespawnByTime();
        this.DistanceToEffect();
        this.DespawnByDistance();
    }
    public virtual void DistanceToEffect()
    {
        this.distanceToDespawn = Vector3.Distance(this.transform.parent.position, this.effectCtrl.GameCtrl.PetCtrl.transform.position);

        if (this.distanceToDespawn > this.distanceDespawn) this.distanceToDespawn = this.distanceDespawn;
    }
    public override void DespawnByDistance()
    {
        if (!this.isDespawnByDistance) return;
        if (distanceToDespawn >= this.distanceDespawn) this.DoDespawn();
    }


    #region LoadComponents
    override protected void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEffectCtrl();
    }

    protected virtual void LoadEffectCtrl()
    {
        if (this.effectCtrl != null) return;
        this.effectCtrl = transform.root.GetComponent<EffectCtrl>();
        Debug.Log(transform.name + ": LoadEffectCtrl", gameObject);
    }
    #endregion
}

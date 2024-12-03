using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCtrl : MMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => this.playerCtrl;

    [SerializeField] protected EffectCtrl effectCtrl;
    public EffectCtrl EffectCtrl => this.effectCtrl;

    [SerializeField] protected PetAttackPoint petAttackPoint;
    public PetAttackPoint PetAttackPoint => this.petAttackPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
        this.LoadEffectCtrl();
        this.LoadPetAttackPoint();
    }


    protected virtual void LoadPetAttackPoint()
    {
        if (this.petAttackPoint != null) return;
        this.petAttackPoint = GetComponentInChildren<PetAttackPoint>();
        Debug.Log(transform.name + ": LoadPetAttackPoint", gameObject);
    }
    protected virtual void LoadEffectCtrl()
    {
        if (this.effectCtrl != null) return;
        this.effectCtrl = GameObject.Find("Effect").GetComponent<EffectCtrl>();
        Debug.Log(transform.name + ": LoadEffectCtrl", gameObject);
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }

}

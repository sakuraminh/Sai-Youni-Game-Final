using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCtrl : MMonoBehaviour
{
    [SerializeField] protected GameCtrl gameCtrl;
    public GameCtrl GameCtrl => this.gameCtrl;

    [SerializeField] protected PetAttackPoint petAttackPoint;
    public PetAttackPoint PetAttackPoint => this.petAttackPoint;

    [SerializeField] protected PetAttack petAttack;
    public PetAttack PetAttack => this.petAttack;




    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameCtrl();
        this.LoadPetAttackPoint();
        this.LoadPetAttack();

    }

    protected virtual void LoadPetAttack()
    {
        if (this.petAttack != null) return;
        this.petAttack = GetComponentInChildren<PetAttack>();
        Debug.Log(transform.name + ": LoadPetAttack", gameObject);
    }

    protected virtual void LoadGameCtrl()
    {
        if (this.gameCtrl != null) return;
        this.gameCtrl = GameObject.Find("GameCtrl").GetComponent<GameCtrl>();
        Debug.Log(transform.name + ": LoadGameCtrl", gameObject);
    }

    protected virtual void LoadPetAttackPoint()
    {
        if (this.petAttackPoint != null) return;
        this.petAttackPoint = GetComponentInChildren<PetAttackPoint>();
        Debug.Log(transform.name + ": LoadPetAttackPoint", gameObject);
    }
}

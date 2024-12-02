using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAttack : PetAbs
{
    [SerializeField] protected PetMoving petMoving;
    public PetMoving PetMoving => this.petMoving;

    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 3f;

    [SerializeField] protected bool isAttack = false;
    public bool IsAttack => this.isAttack;

    protected virtual void Update()
    {
        this.Attacking();
    }
    protected virtual void Attacking()
    {

        if (petCtrl.PlayerCtrl.PlayerRadar.TargetNearest == null)
        {
            this.isAttack = false;
            this.petMoving.SetMoving(!this.isAttack);
            return;
        }
        this.isAttack = true;
        this.petMoving.SetMoving(!this.isAttack);
        this.Attack();
    }
    protected virtual void Attack()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;

        Debug.Log("Attack");
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPetMoving();
    }
    protected virtual void LoadPetMoving()
    {
        if (this.petMoving != null) return;
        this.petMoving = transform.parent.GetComponentInChildren<PetMoving>();
        Debug.Log(transform.name + ": LoadPetMoving", gameObject);
    }

}

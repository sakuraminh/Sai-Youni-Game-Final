using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAttack : PetAbs
{
    [SerializeField] protected PetMoving petMoving;
    public PetMoving PetMoving => this.petMoving;

    [SerializeField] protected string BulletName = "Bullet01";

    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 0.5f;




    [SerializeField] protected bool isAttack = false;
    public bool IsAttack => this.isAttack;

    [SerializeField] protected Effect bullet;

    protected virtual void Update()
    {
        this.Attacking();
        //this.GetBulletPrefabByName();
    }
    protected virtual void Attacking()
    {

        if (petCtrl.GameCtrl.PlayerCtrl.PlayerRadar.TargetNearest != null && !this.petCtrl.GameCtrl.PlayerCtrl.PlayerMoving.IsMoving)
        {
            this.isAttack = true;
            this.Attack();
            //this.petMoving.SetMoving(!this.isAttack);
            return;
        }
        this.isAttack = false;
        //this.petMoving.SetMoving(!this.isAttack);

    }
    protected virtual void Attack()
    {
        this.timer += Time.deltaTime;
        if (this.timer < this.delay) return;
        this.timer = 0;

        Effect bulletPrefab = this.GetBulletPrefabByName();
        this.bullet = bulletPrefab;
        if (bulletPrefab == null)
        {
            Debug.Log("bullets not found");
            return;
        }
        transform.parent.LookAt(petCtrl.GameCtrl.PlayerCtrl.PlayerRadar.TargetNearest.transform);

        Effect newBullet = petCtrl.GameCtrl.EffectCtrl.EffectSpawner.Spawn(bulletPrefab, petCtrl.PetAttackPoint.transform.position, petCtrl.PetAttackPoint.transform.rotation);
        newBullet.gameObject.SetActive(true);
    }

    protected virtual Effect GetBulletPrefabByName()
    {
        foreach (Effect prefab in this.petCtrl.GameCtrl.EffectCtrl.EffectPrefab.Prefabs)
            if (prefab.GetName() == this.BulletName)
            {
                //this.bullet = prefab;
                return prefab;
            }
        return null;
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

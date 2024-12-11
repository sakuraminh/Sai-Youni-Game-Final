using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyPrefabAbs
{
    [SerializeField] protected string BulletName = "Bullet01";
    [SerializeField] protected float RemainingDistance = 15f;
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 0.5f;

    [SerializeField] protected bool isAttack = false;
    public bool IsAttack => this.isAttack;

    [SerializeField] protected Effect bullet;

    protected virtual void Update()
    {
        this.Attacking();
    }
    public virtual void Attacking()
    {
        if (EnemyPrefabCtrl.EnemyRadar.TargetNearest != null && this.enemyPrefabCtrl.EnemyRadar.DistanceNearest <= RemainingDistance)
        {
            this.isAttack = true;
            if (this.enemyPrefabCtrl.EnemyMoving.IsMoving == this.isAttack)
            {
                this.enemyPrefabCtrl.EnemyMoving.SetMoving(!this.isAttack);
            }
            this.Attack(EnemyPrefabCtrl.EnemyRadar.TargetNearest);
            return;
        }
        this.isAttack = false;
        if (this.enemyPrefabCtrl.EnemyMoving.IsMoving == this.isAttack)
        {
            this.enemyPrefabCtrl.EnemyMoving.SetMoving(!this.isAttack);
        }
    }
    protected virtual void Attack(PlayerCheck enemyCheck)
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
        transform.parent.LookAt(enemyCheck.transform);

        Effect newBullet = EnemyCtrl.GameCtrl.EffectCtrl.EffectSpawner.Spawn(bulletPrefab, EnemyPrefabCtrl.AttackPoint.transform.position, EnemyPrefabCtrl.AttackPoint.transform.rotation);
        newBullet.gameObject.SetActive(true);
    }
    protected virtual Effect GetBulletPrefabByName()
    {
        foreach (Effect prefab in this.EnemyCtrl.GameCtrl.EffectCtrl.EffectPrefab.Prefabs)
            if (prefab.GetName() == this.BulletName)
            {
                return prefab;
            }
        return null;
    }
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    #endregion
}

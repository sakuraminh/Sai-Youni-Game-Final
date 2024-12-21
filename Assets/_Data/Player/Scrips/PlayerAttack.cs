using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerAbs
{
    [SerializeField] protected float currentMP = 20;
    public float CurrentMP => this.currentMP;

    [SerializeField] protected float maxMP = 20;
    public float MaxMP => this.maxMP;

    [SerializeField] protected float reduceMP = 1;
    [SerializeField] protected float attackCooldown = 1f, attackTimer;
    [SerializeField] protected string BulletName = "Projectile1";

    [SerializeField] protected Effect bullet;
    public virtual void Attack(EnemyCheck enemyCheck)
    {
        if (enemyCheck == null)
        {
            Debug.Log("enemyCheck is null");
            return;
        }
        Effect bulletPrefab = this.GetBulletPrefabByName();
        this.bullet = bulletPrefab;
        if (bulletPrefab == null)
        {
            Debug.Log("bullets not found");
            return;
        }
        playerCtrl.PlayerSenEffectPoint.transform.LookAt(enemyCheck.transform);

        this.ReduceMana(this.reduceMP);

        Effect newBullet = playerCtrl.GameCtrl.EffectCtrl.EffectSpawner.Spawn(bulletPrefab, playerCtrl.PlayerSenEffectPoint.transform.position, playerCtrl.PlayerSenEffectPoint.transform.rotation);
        newBullet.gameObject.SetActive(true);
    }

    protected virtual void ReduceMana(float value)
    {
        if (currentMP > 0)
        {
            currentMP -= value;
            playerCtrl.GameCtrl.UICtrl.PlayerHPUI.UpdateSlider();
        }

        if (currentMP < 0) currentMP = 0;

    }

    public virtual void RestoreMana(float value)
    {
        if (currentMP < maxMP)
        {
            currentMP += value;
            playerCtrl.GameCtrl.UICtrl.PlayerHPUI.UpdateSlider();
        }
        if (currentMP > maxMP) currentMP = maxMP;
    }

    protected virtual Effect GetBulletPrefabByName()
    {
        foreach (Effect prefab in this.playerCtrl.GameCtrl.EffectCtrl.EffectPrefab.Prefabs)
            if (prefab.GetName() == this.BulletName)
            {
                return prefab;
            }
        return null;
    }
    public void DefaultAttackEnemy(EnemyCheck enemyCheck)
    {
        if (this.currentMP <= 0)
        {
            Debug.Log("không đủ MP");
            return;
        }
        transform.parent.LookAt(enemyCheck.transform);
        transform.parent.rotation = Quaternion.Euler(0, transform.parent.rotation.eulerAngles.y, transform.parent.rotation.eulerAngles.z);
        this.playerCtrl.Animator.SetInteger("AttackIndex", 0);
        this.playerCtrl.Animator.SetTrigger("Attack");
    }




    #region LoadComponents
    #endregion

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerAbs
{
    [SerializeField] protected float attackCooldown = 1f, attackTimer;
    [SerializeField] protected string BulletName = "Bullet01";

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

        Effect newBullet = playerCtrl.GameCtrl.EffectCtrl.EffectSpawner.Spawn(bulletPrefab, playerCtrl.PlayerSenEffectPoint.transform.position, playerCtrl.PlayerSenEffectPoint.transform.rotation);
        newBullet.gameObject.SetActive(true);
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
        transform.parent.LookAt(enemyCheck.transform);
        transform.parent.rotation = Quaternion.Euler(0, transform.parent.rotation.eulerAngles.y, transform.parent.rotation.eulerAngles.z);
        this.playerCtrl.Animator.SetInteger("AttackIndex", 0);
        this.playerCtrl.Animator.SetTrigger("Attack");
    }




    #region LoadComponents
    #endregion

}

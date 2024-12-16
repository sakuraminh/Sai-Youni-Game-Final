using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyPrefabAbs
{
    [SerializeField] protected string BulletName = "Bullet01";
    [SerializeField] protected Effect bullet;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected bool isAttack;

    public virtual void Attack(PlayerCheck enemyCheck)
    {
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

    public virtual void SetIsAttack(bool isAttack)
    {
        this.isAttack = isAttack;
    }
    #region LoadComponents
    #endregion
}

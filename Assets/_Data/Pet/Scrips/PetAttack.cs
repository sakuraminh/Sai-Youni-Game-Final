using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAttack : PetPrefabAbs
{
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
        PetPrefabCtrl.PetSenDamePoint.transform.LookAt(enemyCheck.transform);

        Effect newBullet = petCtrl.GameCtrl.EffectCtrl.EffectSpawner.Spawn(bulletPrefab, PetPrefabCtrl.PetSenDamePoint.transform.position, PetPrefabCtrl.PetSenDamePoint.transform.rotation);
        newBullet.gameObject.SetActive(true);
    }
    protected virtual Effect GetBulletPrefabByName()
    {
        foreach (Effect prefab in this.petCtrl.GameCtrl.EffectCtrl.EffectPrefab.Prefabs)
            if (prefab.GetName() == this.BulletName)
            {
                return prefab;
            }
        return null;
    }
    #region LoadComponents
    #endregion
}

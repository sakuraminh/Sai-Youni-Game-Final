using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : EnemyPrefabAbs
{
    [SerializeField] protected SenDamePoint senDamePoint;
    public SenDamePoint SenDamePoint => this.senDamePoint;
    public virtual void StartAttack()
    {
        this.senDamePoint.gameObject.SetActive(true);
        AudioManage.Instance.PlaySFX(AudioManage.Instance.enemyAttack);
    }
    public virtual void EndAttack()
    {
        this.senDamePoint.gameObject.SetActive(false);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSenDamePoint();
    }

    protected virtual void LoadSenDamePoint()
    {
        if (this.senDamePoint != null) return;
        this.senDamePoint = transform.parent.GetComponentInChildren<SenDamePoint>();
        Debug.Log(transform.name + ": LoadSenDamePoint", gameObject);
    }
}

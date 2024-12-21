
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDameReceive : DameReceive
{

    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => this.playerCtrl;

    [SerializeField] protected float currenHp = 20;
    public float CurrentHp => this.currenHp;

    [SerializeField] protected int maxHp = 20;
    public int MaxHp => this.maxHp;

    protected override void OnTriggerEnter(Collider collider)
    {
        this.OnAnimation(collider);
    }
    public override void Receive(int dame)
    {
        if (!isImmortal) this.currenHp -= dame;
        if (this.currenHp < 0) this.currenHp = 0;
        if (this.isDead != true)
        {
            this.playerCtrl.Animator.SetTrigger("isHit");
            AudioManage.Instance.PlaySFX(AudioManage.Instance.playerHit);
        }
        //this.prefabCtrl.EnemyHPUI.UpdateSlider();
        if (this.SetIsDead()) this.OnDead();
        else this.OnHurt();
    }
    public override bool SetIsDead()
    {
        return this.isDead = this.currenHp <= 0;
    }
    protected override void OnDead()
    {
        this.playerCtrl.Animator.SetBool("isMoving", !this.isDead);
        this.playerCtrl.Animator.SetBool("isDead", this.isDead);
        AudioManage.Instance.PlaySFX(AudioManage.Instance.playerDie);
        this.capsuleCollider.enabled = false;
        Invoke(nameof(this.EnableReLoadSince), 5f);
    }

    protected virtual void EnableReLoadSince()
    {
        this.playerCtrl.GameCtrl.UICtrl.ReloadSince.EnableBackGround();
    }
    protected override void OnHurt()
    {
        //
    }
    protected virtual void OnAnimation(Collider collider) //sử dụng OnTriggerStay và kiểm tra activeSelf
    {
    }

    protected virtual void SetHitFalse()
    {
    }
    protected virtual void CallDespawn()
    {
        //this.prefabCtrl.Enemy.Despawn.DoDespawn();
        //this.RemoveTargetCheckFromEnemySpawnAreas(this.prefabCtrl.EnemyCheck);
        //this.RemoveTargetCheckFromPlayer(this.prefabCtrl.EnemyCheck);
        //this.RemoveTargetCheckFromPlayerSelect(this.prefabCtrl.EnemyCheck);
    }
    protected virtual void RemoveTargetCheckFromPlayer(EnemyCheck targetCheck)
    {
    }

    protected virtual void RemoveTargetCheckFromPlayerSelect(EnemyCheck targetCheck)
    {
    }
    protected virtual void RemoveTargetCheckFromEnemySpawnAreas(EnemyCheck targetCheck)
    {

    }

    public virtual void Heal(float value)
    {
        this.currenHp += value;
        if (this.currenHp > this.maxHp) this.currenHp = this.maxHp;
    }
    protected override void Reborn()
    {
        this.currenHp = this.maxHp;
        this.capsuleCollider.enabled = true;
    }
    #region LoadComponents

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.root.GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
    protected override void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }


    #endregion
}
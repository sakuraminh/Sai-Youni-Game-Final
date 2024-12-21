using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPrefabCtrl : MMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl => this.enemyCtrl;

    [SerializeField] protected Enemy enemy;
    public Enemy Enemy => enemy;

    [SerializeField] protected EnemyMoving enemyMoving;
    public EnemyMoving EnemyMoving => enemyMoving;

    [SerializeField] protected EnemyCheck enemyCheck;
    public EnemyCheck EnemyCheck => enemyCheck;

    [SerializeField] protected EnemyDameReceive enemyDameReceive;
    public EnemyDameReceive EnemyDameReceive => enemyDameReceive;

    [SerializeField] protected EnemyHPUI enemyHPUI;
    public EnemyHPUI EnemyHPUI => enemyHPUI;

    [SerializeField] protected EnemyRadar enemyRadar;
    public EnemyRadar EnemyRadar => enemyRadar;

    [SerializeField] protected EnemyAttack enemyAttack;
    public EnemyAttack EnemyAttack => enemyAttack;

    [SerializeField] protected Transform attackPoint;
    public Transform AttackPoint => attackPoint;

    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    [SerializeField] protected NavMeshAgent meshAgent;
    public NavMeshAgent MeshAgent => meshAgent;

    [SerializeField] protected EnemyRadarAttack enemyRadarAttack;
    public EnemyRadarAttack EnemyRadarAttack => enemyRadarAttack;


    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyMoving();
        this.LoadEnemy();
        this.LoadEnemyCtrl();
        this.LoadEnemyCheck();
        this.LoadEnemyDameReceive();
        this.LoadEnemyHPUI();
        this.LoadEnemyRadar();
        this.LoadAttackPoint();
        this.LoadEnemyAttack();
        this.LoadAnimator();
        this.LoadMeshAgent();
        this.LoadEnemyRadarAttack();
    }

    protected virtual void LoadEnemyRadarAttack()
    {
        if (this.enemyRadarAttack != null) return;
        this.enemyRadarAttack = this.GetComponentInChildren<EnemyRadarAttack>();
        Debug.Log(transform.name + ": LoadEnemyRadarAttack", gameObject);
    }

    protected virtual void LoadMeshAgent()
    {
        if (this.meshAgent != null) return;
        this.meshAgent = this.GetComponent<NavMeshAgent>();
        Debug.Log(transform.name + ": LoadMeshAgent", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = this.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    protected virtual void LoadEnemyAttack()
    {
        if (this.enemyAttack != null) return;
        this.enemyAttack = this.GetComponentInChildren<EnemyAttack>();
        Debug.Log(transform.name + ": LoadEnemyAttack", gameObject);
    }

    protected virtual void LoadAttackPoint()
    {
        if (this.attackPoint != null) return;
        this.attackPoint = this.transform.Find("AttackPoint");
        Debug.Log(transform.name + ": LoadAttackPoint", gameObject);
    }

    protected virtual void LoadEnemyRadar()
    {
        if (this.enemyRadar != null) return;
        this.enemyRadar = this.GetComponentInChildren<EnemyRadar>();
        Debug.Log(transform.name + ": LoadEnemyRadar", gameObject);
    }

    protected virtual void LoadEnemyHPUI()
    {
        if (this.enemyHPUI != null) return;
        this.enemyHPUI = this.GetComponentInChildren<EnemyHPUI>();
        Debug.Log(transform.name + ": LoadEnemyHPUI", gameObject);
    }

    protected virtual void LoadEnemyDameReceive()
    {
        if (this.enemyDameReceive != null) return;
        this.enemyDameReceive = this.GetComponentInChildren<EnemyDameReceive>();
        Debug.Log(transform.name + ": LoadEnemyDameReceive", gameObject);
    }

    protected virtual void LoadEnemyCheck()
    {
        if (this.enemyCheck != null) return;
        this.enemyCheck = this.GetComponentInChildren<EnemyCheck>();
        Debug.Log(transform.name + ": LoadEnemyCheck", gameObject);
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = this.GetComponentInParent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected virtual void LoadEnemy()
    {
        if (this.enemy != null) return;
        this.enemy = this.GetComponent<Enemy>();
        Debug.Log(transform.name + ": LoadEnemy", gameObject);
    }
    protected virtual void LoadEnemyMoving()
    {
        if (this.enemyMoving != null) return;
        this.enemyMoving = this.GetComponentInChildren<EnemyMoving>();
        Debug.Log(transform.name + ": LoadEnemyMoving", gameObject);
    }
    #endregion
}

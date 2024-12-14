using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : EnemyPrefabAbs
{
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 8f;
    [SerializeField] protected float patrolRange = 15f;
    [SerializeField] protected float attackCooldown = 3f;
    [SerializeField] protected Vector3 startPosition;
    [SerializeField] protected Vector3 randomPatrolPoint;
    [SerializeField] protected float attackTimer;
    [SerializeField] protected bool isMoving;
    [SerializeField] protected bool isAttacking;

    protected enum EnemyState
    {
        Patrolling,
        Chasing,
        Attacking,
        Returning
    }
    [SerializeField]
    protected EnemyState currentState;

    protected override void OnEnable()
    {
        base.OnEnable();
        startPosition = transform.position;
        SetRandomPatrolPoint();
        currentState = EnemyState.Patrolling;
        attackTimer = 5f;

    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrolling:
                Patrol();
                if (this.EnemyPrefabCtrl.EnemyRadar.PlayerInSightRange() == true)
                {
                    this.attackTimer = 5f;
                    currentState = EnemyState.Chasing;
                }
                break;

            case EnemyState.Chasing:
                ChasePlayer();
                if (this.EnemyPrefabCtrl.EnemyRadarAttack.PlayerInAttackRange() == true)
                {
                    currentState = EnemyState.Attacking;
                }
                else if (this.EnemyPrefabCtrl.EnemyRadar.PlayerInSightRange() == false)
                {
                    this.attackTimer = 5f;
                    currentState = EnemyState.Returning;
                }
                break;

            case EnemyState.Attacking:
                AttackPlayer();
                if (this.EnemyPrefabCtrl.EnemyRadarAttack.PlayerInAttackRange() == false)
                {
                    currentState = EnemyState.Chasing;
                }
                break;

            case EnemyState.Returning:
                ReturnToStart();
                if (this.EnemyPrefabCtrl.EnemyRadar.PlayerInSightRange() == true)
                {
                    this.attackTimer = 5f;
                    currentState = EnemyState.Chasing;
                }
                break;
        }
    }

    protected virtual void UpdateAnimation(bool isMoving, bool isAttacking)
    {
        this.isMoving = isMoving;
        this.isAttacking = isAttacking;
        this.EnemyPrefabCtrl.Animator.SetBool("isMoving", isMoving);
        this.EnemyPrefabCtrl.Animator.SetBool("isAttacking", isAttacking);
    }

    protected virtual void UpdateSpeet(float speed, float acceleration)
    {
        this.EnemyPrefabCtrl.MeshAgent.speed = speed;
        this.EnemyPrefabCtrl.MeshAgent.acceleration = acceleration;
    }

    private void Patrol()
    {
        if (Vector3.Distance(transform.position, randomPatrolPoint) < 0.1f)
        {
            if (this.timer < this.delay)
            {
                this.UpdateAnimation(false, false);
                this.timer += Time.deltaTime;
                return;
            }

            SetRandomPatrolPoint();
            this.timer = 0;
        }
        this.EnemyPrefabCtrl.MeshAgent.SetDestination(randomPatrolPoint);
        this.UpdateSpeet(1, 5);
        this.UpdateAnimation(true, false);

    }

    private void SetRandomPatrolPoint()
    {
        randomPatrolPoint = startPosition + new Vector3(Random.Range(-patrolRange, patrolRange), 0, Random.Range(-patrolRange, patrolRange));
    }
    private void ChasePlayer()
    {
        if (this.EnemyPrefabCtrl.EnemyRadar.PlayerInSightRange() == false) return;
        this.UpdateSpeet(5, 5);
        this.UpdateAnimation(true, false);
        this.EnemyPrefabCtrl.MeshAgent.SetDestination(this.EnemyPrefabCtrl.EnemyRadar.TargetNearest.transform.position);

    }
    private void AttackPlayer()
    {
        float timeAnimation = 3f;

        this.EnemyPrefabCtrl.MeshAgent.SetDestination(transform.position);
        this.UpdateAnimation(false, false);

        attackTimer += Time.deltaTime;

        if (attackTimer >= attackCooldown + timeAnimation)
        {
            Debug.Log("Enemy attacks!");
            //this.EnemyPrefabCtrl.EnemyAttack.Attack(this.EnemyPrefabCtrl.EnemyRadarAttack.TargetNearest);
            this.UpdateAnimation(false, true);
            attackTimer = 0f;
        }
    }
    private void ReturnToStart()
    {
        this.EnemyPrefabCtrl.MeshAgent.SetDestination(startPosition);
        this.UpdateSpeet(5, 5);
        this.UpdateAnimation(true, false);

        if (Vector3.Distance(transform.position, startPosition) < 1f)
        {
            this.UpdateSpeet(1, 5);
            currentState = EnemyState.Patrolling;
        }
    }
}

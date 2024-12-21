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

    [SerializeField] protected float range = 7, validRange = 5;

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
        this.CheckPatrolPointRandom();
        currentState = EnemyState.Patrolling;
        attackTimer = 5f;

    }

    void Update()
    {
        if (enemyPrefabCtrl.EnemyDameReceive.IsDead == false)
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
        else this.EnemyPrefabCtrl.MeshAgent.SetDestination(transform.position);

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

            CheckPatrolPointRandom();
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

    protected virtual void CheckPatrolPointRandom()
    {
        if (isMoving == false)
        {
            if (EnemyCtrl.GameCtrl.Helper.RandomPointOnNavMesh.RandomPoint(startPosition, range, validRange, out Vector3 point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                this.randomPatrolPoint = point;
                return;
            }
            this.CheckPatrolPointRandom();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    private EnemyAnimator enemyAnimator;
    private NavMeshAgent navMeshAgent;

    private EnemyState enemyState;
    public float walkSpeed = 0.5f;
    public float runSpeed = 4f;
    public float chaseDistance = 7f;
    private float currentChaseDistance;
    public float attackDistance = 1.8f;
    public float chaseAfterAttackDistance = 2f;

    public float patrolRadiusMin = 20f;
    public float patrolRadiusMax = 60f;
    public float patrolForThisTime = 15f;
    private float patrolTimer;

    public float waitBeforeAttack = 2f;
    private float attackTimer;

    private Transform target;

    public GameObject attackPoint;

    void Awake()
    {
        enemyAnimator = GetComponent<EnemyAnimator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag(Tags.PLAYER).transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyState = EnemyState.PATROL;
        patrolTimer = patrolForThisTime;
        attackTimer = waitBeforeAttack;
        currentChaseDistance = chaseDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyState == EnemyState.PATROL)
        {
            Patrol();
        }
        if (enemyState == EnemyState.CHASE)
        {
            Chase();
        }
        if (enemyState == EnemyState.ATTACK)
        {
            Attack();
        }
    }

    void Patrol()
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = walkSpeed;

        patrolTimer += Time.deltaTime;
        if (patrolTimer > patrolForThisTime)
        {
            SetNewRandomDestination();
            patrolTimer = 0f;
        }

        if (navMeshAgent.velocity.sqrMagnitude > 0)
        {
            enemyAnimator.Walk(true);
        }
        else
        {
            enemyAnimator.Walk(false);
        }

        if (Vector3.Distance(transform.position, target.position) <= chaseDistance)
        {
            enemyAnimator.Walk(false);
            enemyState = EnemyState.CHASE;
        }
    }

    void Chase()
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = runSpeed;

        navMeshAgent.SetDestination(target.position);

        if (navMeshAgent.velocity.sqrMagnitude > 0)
        {
            enemyAnimator.Run(true);
        }
        else
        {
            enemyAnimator.Run(false);
        }

        if (Vector3.Distance(transform.position, target.position) <= attackDistance)
        {
            enemyAnimator.Run(false);
            enemyAnimator.Walk(false);
            enemyState = EnemyState.ATTACK;

            if (chaseDistance != currentChaseDistance)
            {
                chaseDistance = currentChaseDistance;
            }
        }
        else if (Vector3.Distance(transform.position, target.position) > chaseDistance)
        {
            enemyAnimator.Run(false);
            enemyState = EnemyState.PATROL;
            patrolTimer = patrolForThisTime;

            if (chaseDistance != currentChaseDistance)
            {
                chaseDistance = currentChaseDistance;
            }
        }
    }

    void Attack()
    {
        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.isStopped = true;

        attackTimer += Time.deltaTime;
        if (attackTimer > waitBeforeAttack)
        {
            enemyAnimator.Attack();
            attackTimer = 0f;
        }

        if (Vector3.Distance(transform.position, target.position) > attackDistance + chaseAfterAttackDistance)
        {
            enemyState = EnemyState.CHASE;
        }
    }

    void SetNewRandomDestination()
    {
        float randomRadius = Random.Range(patrolRadiusMin, patrolRadiusMax);
        Vector3 randomDirection = Random.insideUnitSphere * randomRadius;
        randomDirection += transform.position;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, randomRadius, -1);

        navMeshAgent.SetDestination(navHit.position);
    }

    public EnemyState EnemyState { get; set; }

    public void TurnOnAttackPoint()
    {
        attackPoint.SetActive(true);
    }

    public void TurnOffAttackPoint()
    {
        if (attackPoint.activeInHierarchy)
            attackPoint.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    private EnemyAnimator enemyAnimator;
    private NavMeshAgent navMeshAgent;
    private EnemyController enemyController;

    public float health = 100f;

    public bool isPlayer, isAnimal;
    private bool isDead;
    private EnemySounds enemySounds;

    private PlayerStats playerStats;

    void Awake()
    {
        if (isAnimal)
        {
            enemyAnimator = GetComponent<EnemyAnimator>();
            enemyController = GetComponent<EnemyController>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            enemySounds = GetComponentInChildren<EnemySounds>();
        }
        if (isPlayer)
        {
            playerStats = GetComponent<PlayerStats>();
        }
    }

    public void DealDamage(float damage)
    {
        if (!isDead)
        {
            health -= damage;

            if (isPlayer)
            {
                playerStats.DisplayHealthStats(health);
            }
            if (isAnimal)
            {
                if (enemyController.EnemyState == EnemyState.PATROL)
                {
                    enemyController.chaseDistance = 80f;
                }
            }

            if (health <= 0)
            {
                Died();
                isDead = true;
            }
        }
    }

    private void Died()
    {
        if (isAnimal)
        {
            navMeshAgent.velocity = Vector3.zero;
            navMeshAgent.isStopped = true;
            enemyController.enabled = false;
            enemyAnimator.Dead();

            StartCoroutine(DeadSound());

            Invoke("TurnOffGameObject", 3f);
        }
        if (isPlayer)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY);

            foreach(var enemy in enemies)
            {
                enemy.GetComponent<EnemyController>().enabled = false;
            }

            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<WeaponManager>().GetCurrentWeapon().gameObject.SetActive(false);

            Invoke("RestartGame", 3f);
        }
    }

    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scenes.GAME);
    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }

    IEnumerator DeadSound()
    {
        yield return new WaitForSeconds(0.3f);
        enemySounds.PlayDieSound();
    }
}

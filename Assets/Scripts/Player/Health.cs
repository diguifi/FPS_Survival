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

    void Awake()
    {
        if (isAnimal)
        {
            enemyAnimator = GetComponent<EnemyAnimator>();
            enemyController = GetComponent<EnemyController>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        if (isPlayer)
        {
            // etc
        }
    }

    public void DealDamage(float damage)
    {
        if (!isDead)
        {
            health -= damage;

            if (isPlayer)
            {
                // update stats
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
}

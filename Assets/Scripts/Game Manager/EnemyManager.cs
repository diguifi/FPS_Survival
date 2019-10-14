using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [SerializeField]
    private GameObject boarPrefab;
    public Transform[] boarSpawnPoints;

    [SerializeField]
    private int boarCount;
    private int initialBoarCount;

    public float waitBeforeSpawn = 10f;

    void Awake()
    {
        CreateInstance();
    }

    void Start()
    {
        initialBoarCount = boarCount;

        SpawnEnemies();
        StartCoroutine("CheckToSpawnEnemies");
    }

    void CreateInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void SpawnEnemies()
    {
        SpawnBoars();
    }

    void SpawnBoars()
    {
        int index = 0;
        for (int i = 0; i < boarCount; i++)
        {
            if (index >= boarSpawnPoints.Length)
            {
                index = 0;
            }

            Instantiate(boarPrefab, boarSpawnPoints[index].position, Quaternion.identity);
            index++;
        }
        boarCount = 0;
    }

    IEnumerator CheckToSpawnEnemies()
    {
        yield return new WaitForSeconds(waitBeforeSpawn);
        SpawnEnemies();
        StartCoroutine("CheckToSpawnEnemies");
    }

    public void EnemyDied(Enemies enemy)
    {
        if (enemy == Enemies.Boar)
        {
            boarCount++;

            if (boarCount > initialBoarCount)
            {
                boarCount = initialBoarCount;
            }
        }
    }

    public void StopSpawning()
    {
        StopCoroutine("CheckToSpawnEnemies");
    }
}

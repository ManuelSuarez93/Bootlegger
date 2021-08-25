using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class SpawnTD : MonoBehaviour
{
    [SerializeField] private Transform[] spawners;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private UnityEvent spawnEvent;

    [SerializeField] private float timer;
    [SerializeField] private float maxtime;
    [SerializeField] private int maxSpawnsOnce;


    void Update()
    {
        if(timer <= maxtime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawn();
            timer = 0;
        }
    }
    
    public void spawn()
    {
        int amount = UnityEngine.Random.Range(1, maxSpawnsOnce);
        for (int i = 0; i < amount; i++)
        {
            int spawner = UnityEngine.Random.Range(0, spawners.Length);
            print("Spawner " + spawner);
            int enemy = UnityEngine.Random.Range(0, enemies.Length);

            GameObject enemyspawn = Instantiate(enemies[enemy],transform);
            enemyspawn.GetComponent<HealthTD>().deathEvent.AddListener(delegate { spawnEvent.Invoke(); });

            enemyspawn.transform.position = spawners[spawner].transform.position;
        }
       
    }
}

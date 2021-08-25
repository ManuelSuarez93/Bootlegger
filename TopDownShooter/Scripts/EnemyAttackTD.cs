using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyAttackTD : MonoBehaviour
{
   
    [SerializeField] private bool attack;
    [SerializeField] private float attackTimer;
    [SerializeField] private float attackDelay;
    [SerializeField] private int damage;
    [SerializeField] private UnityEvent attackEvent;
    [SerializeField] private HealthTD playerHealth;
    [SerializeField] private Animator eAnimator;

    private AudioSource aSource;

    private void Awake()
    {
        aSource = GetComponent<AudioSource>();
        eAnimator = GetComponent<Animator>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthTD>();
    }


    void Update()
    {
        if (attack && playerHealth != null && attackTimer <= 0)
        {
            eAnimator.SetTrigger("Attack");
            playerHealth.modifyHealth(damage);
            attackTimer = attackDelay;
            aSource.Play();
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }
    }

    public void canAttack(bool canAttack)
    {
        attack = canAttack;
    }

    
}

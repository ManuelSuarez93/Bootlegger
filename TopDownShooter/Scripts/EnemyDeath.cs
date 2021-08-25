using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    TopDownShooterGameManager tm;
    
    public void enemyDies()
    {
        tm.enemyKilled();
    }
}

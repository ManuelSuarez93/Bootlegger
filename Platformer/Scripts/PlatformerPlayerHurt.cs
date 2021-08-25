using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformerPlayerHurt : MonoBehaviour
{
    public LayerMask dangerLayer;
    public UnityEvent deathEvent;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            deathEvent.Invoke();
        }
    }
}

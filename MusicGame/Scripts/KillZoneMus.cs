using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillZoneMus : MonoBehaviour
{
    public UnityEvent killEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ObjMus"))
        {
            Destroy(collision.gameObject);
            killEvent.Invoke();
        }
    }
}

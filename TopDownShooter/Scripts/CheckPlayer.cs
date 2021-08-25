using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private LayerMask collisionLayer;
    public Transform SightCheck()
    {
        Debug.Log("IS PLAYER SIGHTED: " + Physics2D.Raycast(transform.position, transform.right, distance, collisionLayer));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance, collisionLayer);
        if (hit) 
        {   
            if (hit.transform.CompareTag("Player"))
            {
                Debug.DrawRay(transform.position, transform.right * hit.distance, Color.red);
                return hit.transform;
            }
            else
            { 
                Debug.DrawRay(transform.position, transform.right * hit.distance, Color.yellow);
                return null; 
            }
        }
        else 
        { 
            Debug.DrawRay(transform.position, transform.right * distance); 
            return null; 
        }
    }
}

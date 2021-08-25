using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingPlatform : MonoBehaviour
{
    Transform playtr;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            playtr = collision.collider.transform;
        }
        else
        {
            playtr = null;
        }
        collision.collider.transform.SetParent(transform);
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform.parent.parent.parent.parent);
        collision.collider.transform.rotation = Quaternion.identity;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressButton : MonoBehaviour
{
    Animator animator;
    bool playinside;
    bool activado = false;
    public TriggerBomba tb;
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        
        if(Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("ButtonPress");
        }
        
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Figura")) 
        { 
            playinside = true;
            tb = collision.gameObject.GetComponent<TriggerBomba>();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Figura")) { playinside = false;  tb = null; }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LayerSwapBomb : MonoBehaviour
{
    public UnityEvent enter;
    public UnityEvent exit;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjMus")) { enter.Invoke(); }  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjMus")) { exit.Invoke(); }
    }
}

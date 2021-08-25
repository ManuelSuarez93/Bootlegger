using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterBtnMus : MonoBehaviour
{

    public GameObject currentObjMus;
    public bool inside;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjMus"))
        {
            inside = true;
            currentObjMus = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjMus"))
        {
            inside = false;
            currentObjMus = null;
        }
    }
}

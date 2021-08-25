using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    [SerializeField] Camera cam;
    private void Start()
    {

    }
    void Update()
    {

        Vector2 mousePosition = Input.mousePosition;
        mousePosition = cam.ScreenToWorldPoint(mousePosition);
        transform.position = mousePosition;
    }
}

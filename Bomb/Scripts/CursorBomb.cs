using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBomb : MonoBehaviour
{
    [SerializeField] private Camera cam;
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseposition = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mouseposition.x, mouseposition.y);
    }
}

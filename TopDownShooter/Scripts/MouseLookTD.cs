using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseLookTD : MonoBehaviour
{
    Rigidbody2D _rigid;
    //Animator _anim;

    [SerializeField] private float speed;
    [SerializeField] private Vector2 move;
    [SerializeField] private Vector2 mouseposition;
    [SerializeField] private Transform tr;
    [SerializeField] private Camera cam;
    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        //_anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float velx = Input.GetAxis("Horizontal");
        float vely = Input.GetAxis("Vertical");
        move = new Vector2(velx, vely);
        _rigid.velocity = move * speed;

        mouseposition = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.up = (Vector2)mouseposition - (Vector2)transform.position;
       
        if (tr) tr.position = new Vector3(mouseposition.x, mouseposition.y,1);
        //_anim.SetFloat("MovX",_rigid.velocity.magnitude);

    }

}

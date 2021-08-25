using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class ObjMus : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private Animator _anim;
    public float fallingspeed = 1;
    [SerializeField] private float deathAnimTime;
    [SerializeField] private UnityEvent deathEvent;


    private void Start()
    {
        _anim = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody2D>();
        _rigid.velocity = new Vector2(0, -fallingspeed);
    }

    private void OnDestroy()
    {
        deathEvent.Invoke();
    }


}

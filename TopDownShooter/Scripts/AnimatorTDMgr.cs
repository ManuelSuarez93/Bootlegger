using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTDMgr : MonoBehaviour
{
    private Animator _anim;
    public String _currentState;


    void Start()
    {
        _anim = GetComponent<Animator>();

    }
    private void Update()
    {
        checkState();
    }
    public void checkState()
    {
        switch (_currentState)
        {
            case "Idle": ChangeAnimState("Player_Idle");  break;
            case "Walk": ChangeAnimState("Player_Walk"); break;
            case "Shoot": ChangeAnimState("Player_Shoot"); break;
        }
    }
    void ChangeAnimState(string newState)
    {
        if (_currentState == newState) return;

        _currentState = newState;
        _anim.Play(newState);
    }

}

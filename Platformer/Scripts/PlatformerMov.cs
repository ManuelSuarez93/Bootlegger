using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMov : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private Collider2D _coll;
    private Animator _anim;
    private SpriteRenderer _sprite;
    private AudioSource _as;

    [SerializeField] private LayerMask layer;
    [SerializeField] private float speed;
    [SerializeField] private float jumpheight;

    [SerializeField] private string _currentState;

    private float movx;
    private float movy;

    const string PLATFORMER_IDLE = "Platformer_Idle";
    const string PLATFORMER_WALK = "Platformer_Walk";
    const string PLATFORMER_JUMP = "Platformer_Jump";


    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _coll = GetComponent<Collider2D>();
        _rigid = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _as = GetComponent<AudioSource>();
    }

    void Update()
    {
        Movement();
        Jump();
        AnimatorStateCheck();
        PlaySound();
    }
    void ChangeAnimState(string newState)
    {
        if (_currentState == newState) return;

        _currentState = newState;
        _anim.Play(newState);
    }
    void Movement()
    {
        movx = Input.GetAxis("Horizontal");

        _rigid.velocity = new Vector2(movx*speed, _rigid.velocity.y);
        if(movx < 0){ _sprite.flipX = true; }
        else{ _sprite.flipX = false; }
    }

    void AnimatorStateCheck()
    {
        if(Mathf.Abs(movx) > 0 && movy == 0) { ChangeAnimState(PLATFORMER_WALK); }
        if(Mathf.Abs(movy) > 1) { ChangeAnimState(PLATFORMER_JUMP); }
        if(movx == 0 && movy == 0) 
        { 
            ChangeAnimState(PLATFORMER_IDLE);
        }
    }

    void Jump()
    {
        movy = _rigid.velocity.y;
        RaycastHit2D hit =  Physics2D.Raycast(transform.position - new Vector3(0, _coll.bounds.extents.y + 0.01f, 0), Vector2.down, 0.1f, layer);
        
        if(hit.collider != null)
        {
            if(Input.GetButtonDown("Jump"))
            {
                _rigid.velocity = new Vector2(_rigid.velocity.x, jumpheight);
            }
        }
        Debug.DrawRay(transform.position - new Vector3(0, _coll.bounds.extents.y + 0.01f, 0), Vector2.down);
    }

    void PlaySound()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0 && Mathf.Abs(_rigid.velocity.y) < 0.5)
        {
            if (!_as.isPlaying) { _as.Play(); }
        }
        else
        {
            _as.Stop();
        }
        
    }

}

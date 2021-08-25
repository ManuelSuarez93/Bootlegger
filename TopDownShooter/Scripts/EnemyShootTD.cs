using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootTD : MonoBehaviour
{
    [SerializeField] private float shootTime;
    [SerializeField] private float speed;
    [SerializeField] private GameObject projectile;
    [SerializeField] private LayerMask collisionLayer;
    
    private Animator _anim;
    private AudioSource _as;
    private CheckPlayer _cp;
    private Transform player;
    private float timer;

    void Start()
    {
        timer = 0;
        _as = GetComponent<AudioSource>();
        _cp = GetComponentInParent<CheckPlayer>();
        _anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        player = _cp.SightCheck();
        if(player != null)
        {
            if (player.CompareTag("Player"))
            {
                if (timer > shootTime)
                {
                    _as.Play();
                    _anim.SetTrigger("Attack");
                    GameObject shot = Instantiate(projectile);
                    shot.transform.position = transform.position;
                    shot.transform.right = transform.right;
                    shot.GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
                    timer = 0;
                }
            }
        }
         timer += Time.deltaTime;
    }
}

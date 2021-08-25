using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float timebetween = 1;
    [SerializeField] private float projectilespeed;
    [SerializeField] private Animator _anim;

    private Vector2 direction;
    private AudioSource _as;
    private float timer = 0;
    

    private void Start()
    {
        _as = GetComponent<AudioSource>();
    }
    void Update()
    {
     if (timer <= timebetween)
        {
            timer += Time.deltaTime;
        }
     else
        {
            
            shoot();  
        }

        direction = transform.up;
    }
    void shoot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            _as.Play();
            _anim.SetTrigger("Shooting");
            GameObject m = Instantiate(projectile);
            m.transform.position = transform.position;
            m.transform.right = transform.up;
            m.GetComponent<Rigidbody2D>().velocity = (direction).normalized * projectilespeed;
            timer = 0;
        }
    }

}

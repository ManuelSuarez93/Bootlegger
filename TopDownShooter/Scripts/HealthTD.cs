using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthTD : MonoBehaviour
{
    public float health;
    public float maxhealth;
    [SerializeField] private LayerMask layerM;
    public UnityEvent deathEvent;
    [SerializeField] private UnityEvent hurtEvent;

    private SpriteRenderer _sr;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 1)
        {
            gameObject.SetActive(false);
            deathEvent.Invoke();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((layerM.value & 1 << collision.gameObject.layer) > 0)
        {
            modifyHealth(1);
        }
    }

    public void modifyHealth(int i)
    {
        health -= i;
        hurtEvent.Invoke();
        if(gameObject.CompareTag("Enemy"))
        {
            _sr.color = Color.red;
        }
        
    }

   


}

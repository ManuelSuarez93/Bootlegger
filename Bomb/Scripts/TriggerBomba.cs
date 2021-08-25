using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerBomba : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    
    [SerializeField] Sprite[] useSrpites;
    [SerializeField] private bool isNear;
    [SerializeField] private bool isActivated = false;
    [SerializeField] private int order;


    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if(isNear && !isActivated && Input.GetButtonDown("Fire1"))
        {
            activate();
        }
    }
    
    public void activate()
    {
        print("Activate");
        spriteRenderer.color = Color.black;
        BombGameManager.instance.AddToOrder(order);
        isActivated = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) { spriteRenderer.sprite = useSrpites[1]; }
        isNear = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if(collision.CompareTag("Player")) { spriteRenderer.sprite = useSrpites[0]; }
        isNear = false;
    }
}

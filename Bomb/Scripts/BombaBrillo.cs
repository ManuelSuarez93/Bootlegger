using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaBrillo : MonoBehaviour
{
    private SpriteRenderer sprite;
  
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        sprite.color = Color.Lerp(Color.red,Color.green, BombGameManager.instance.timer/BombGameManager.instance.maxTime);
    }

}

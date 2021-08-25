
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image img;
    
    private HealthTD htdScript;
    private float health;

    private void Start()
    {
        htdScript = GetComponent<HealthTD>();
    }

    // Update is called once per frame
    void Update()
    {
        health = htdScript.health / htdScript.maxhealth;
        img.fillAmount = health;
    }
}

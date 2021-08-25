using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreChange : MonoBehaviour
{
    Text scoreup;

    public void Start()
    {
        scoreup = GetComponent<Text>();

    }
    public void changed(Int32 i)
    {
        scoreup.text = "+" + i;
    }
}

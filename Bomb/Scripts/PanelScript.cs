using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{
    public List<Image> images;
    public List<Image> childImages;
    public List<Image> childImages2;
    public List<SpriteRenderer> boton;
    public int[] order = new int[4];
    public int currentorder = 0;

    public int max = 4;
    public PanelEvents pevents;
    
    public void Start()
    {
        initG();
    }

    public void initG()
    {
        //Inicializo
        childImages = GetComponentsInChildren<Image>().ToList();
        childImages.RemoveRange(0, 1);

        for (int i = 0; i < childImages.Count; i++)
        {
            Image img = null;
            childImages2.Add(img);
        }
        print(childImages.Count);
        //Randomzio orden

        for (int i = 0; i < childImages.Count; i++)
        {
            int rand = UnityEngine.Random.Range(0, max);
            while (childImages2.Contains(images[rand]) && i != childImages.Count)
            {
                rand = UnityEngine.Random.Range(0, max);
            }

            order[i] = rand;
            childImages[i] = images[rand];
            childImages2[i] = images[rand];
        }
        print("childsprites: " + childImages2.Count);
        print("Order : " + order.Count());
    }
    public void Update()
    {
        if(currentorder == max)
        {
            pevents.eventWon.Invoke();
        }
    }

    public void activate(int i)
    {
        print("activate:" + i);
        if (order[currentorder] == i && currentorder != max)
        {
            currentorder++;
        }
        else
        {
            pevents.eventLose.Invoke();
        }
    }

    [Serializable]
    public class PanelEvents
    {
        public UnityEvent eventWon;
        public UnityEvent eventLose;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpawnObjMus : MonoBehaviour
{
    [SerializeField] private GameObject mus;
    [SerializeField] private MusicGameManager ms;
    [SerializeField] private float currentspeed;
    [SerializeField] private float timeBetweenDrops;
    [SerializeField] private List<Drop> dropList;

    [Serializable]
    internal class Drop
    {
        [SerializeField] public float inBetween;
        [SerializeField] public float amount;
        [SerializeField] public bool noDrop;
    }
    void Start()
    {
        StartCoroutine(routina());
    }

    private void Update()
    { 
       
    }

    /// <summary>
    /// Spawn music object 
    /// </summary>
    public void SpawnObject()
    {
        GameObject m = Instantiate(mus, transform);
        m.transform.position = transform.position;
        m.GetComponent<ObjMus>().fallingspeed = currentspeed;
    }

    IEnumerator routina()
    {
        
        while (ms.currentGameState == GameState.playing)
        {   
            for (int i = 0; i < dropList.Count; i++)
            {
                yield return new WaitForSeconds(timeBetweenDrops);
                for (int j = 0; j < dropList[i].amount; j++)
                {
                    yield return new WaitForSeconds(dropList[i].inBetween);
                    if(!dropList[i].noDrop)
                    {
                        SpawnObject();
                    }
                }
            }
        }
    }


  


}

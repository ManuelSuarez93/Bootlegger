using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWhenDestroy : MonoBehaviour
{
    public GameObject insObj;
    public void InstantiateInDestroy()
    {
        GameObject m = Instantiate(insObj);
        m.transform.position = transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public class SpawnTrash : MonoBehaviour
{
    [SerializeField] private GameObject instance;
    public float maxTime;
    [SerializeField] private List<Transform> transforms;

    [SerializeField] private float timer;
    [SerializeField] private PlatformerManager pm;

    void Start()
    {
        pm = GameObject.Find("PlatformerManager").GetComponent<PlatformerManager>();
    }

    void Update()
    {
        if (timer > maxTime)
        {
            int rand = Random.Range(0, transforms.Count);
            Instantiate(instance, transforms[rand]);
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBombTrigger : MonoBehaviour
{
    [SerializeField] private GameObject TriggerToSpawn;
    [SerializeField] private GameObject FakeTriggertoSpawn;
    [SerializeField] private List<Transform> locations;
    [SerializeField] private List<Transform> usedLocations;
    [SerializeField] private int amount;
    int rand = 0;
    void Start()
    {
        for (int i = 0; i < locations.Count; i++)
        {
            Transform t = null;
            usedLocations.Add(t);
        }

        for (int i = 0; i < amount; i++)
        {
            rand = UnityEngine.Random.Range(0, locations.Count);
            if(i == 0)
            {
                Instantiate(TriggerToSpawn, locations[rand]);
                usedLocations[i] = locations[rand];
            }
            else
            {
                while(usedLocations.Contains(locations[rand]))
                {
                    rand = UnityEngine.Random.Range(0, locations.Count);
                }
                Instantiate(FakeTriggertoSpawn, locations[rand]);
                usedLocations[i] = locations[rand];
            }
        }
    }
            
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using BasicSurvivalKit;

public class BotonMus : MonoBehaviour
{
    #region Variables
    [SerializeField] private TriggerEnterBtnMus[] trigger;
    [SerializeField] private string button;
    [SerializeField] private KeyCode key;
    [SerializeField] private MusicGameManager ms;
    [SerializeField] private int score = 0;
    [SerializeField] private AudioClip[] clips = new AudioClip[4];
    [SerializeField] private AudioSource _as;

    [SerializeField] private UnityEvent destroyEvent;
    private InstantiatePrefab ip;
    #endregion

    #region UnityFunctions
    void Start()
    {
        ip = GetComponent<InstantiatePrefab>();
        _as = GetComponent<AudioSource>();
        trigger = GetComponentsInChildren<TriggerEnterBtnMus>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            triggerEnter();
            destroyMus();
            ms.setScore(score);
            score = 0;
            
        }
    }
    #endregion

    #region ButtonMusFunctions
    void triggerEnter()
    {
        {
            foreach (TriggerEnterBtnMus t in trigger)
            {
                if (t.inside)
                {
                    _as.clip = clips[UnityEngine.Random.Range(0, 3)];
                    _as.Play();
                    t.GetComponent<Animator>().Play("AnimationReceptor");
                    score += 1;
                }
            }
            if(score == 0)
            {
                score = -1;
            }
            switch(score)
            {
                case 1: ip.Instantiate(0); break;
                case 2: ip.Instantiate(1); break;
                case 3: ip.Instantiate(2); MusicGameAchievements.Instance().ChangeVariable("PerfectNotes", 1); break;
                case -1: ip.Instantiate(3); break;
            }
            destroyEvent.Invoke();
        }
    }

    void destroyMus()
    {
        foreach (TriggerEnterBtnMus t in trigger)
        {
            Destroy(t.currentObjMus);
        }
    }
    #endregion

}

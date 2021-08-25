using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    public static StoryManager thisStory;

    [SerializeField] Mail[] mailList;
    [SerializeField] MailManager mailManager;
    [SerializeField] Transform NotifPanel;
    [SerializeField] Transform popup;
    [SerializeField] GameObject btn;

    
    [SerializeField] AudioSource _as;
    [Tooltip("Distance between buttons in notification panel")]
    [SerializeField] float NotifBtnDistance;
    [Tooltip("Event which the new notification button will be created")]
    [SerializeField] UnityEvent btnEvent;
    private Button btnAct;
    [SerializeField] private int btnAdded;
    [SerializeField] List<UnityEvent> events;
    

    void Start()
    {
        btnAdded = 0;
        events[0].Invoke();
    }

    public void TriggerMail(int i)
    {
        //Play Notification sound
        _as.Play();
        //Instantiate Screen popup
        Instantiate(mailList[i].notification, popup);
        //Create notification in NotifPanel and subscirbe to btnEvent
        GameObject InstButn  = Instantiate(btn, NotifPanel);
        InstButn.transform.position = new Vector2(InstButn.transform.position.x-0.5f, InstButn.transform.position.y - ((btnAdded * NotifBtnDistance)) + 1.5f);
        InstButn.GetComponentInChildren<Text>().text = mailList[i].subject;
        btnAdded++;
        btnAct = InstButn.GetComponent<Button>();
        btnAct.onClick.AddListener(btnEvent.Invoke);
        

        mailManager.LoadMail(mailList[i]);
    }





}

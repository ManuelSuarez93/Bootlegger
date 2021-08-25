using BasicSurvivalKit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TopDownShooterGameManager : MonoBehaviour
{
    #region Variables
    public static TopDownShooterGameManager instance;

    [Header("UI")]
    [SerializeField] private Text killsText;
    [SerializeField] private Text timerText;
    [SerializeField] private Text currentLives;

    [Header("Player")]
    [SerializeField] private GameObject player;
    [SerializeField] private TimeEvent timeEvent;

    [Header("Set timer for level")]
    [SerializeField] private float maxTimer;
    private int kills;
    private GameState currentGameState;

    private float timer;
    
    #endregion

    #region UnityFunctions
    void Start()
    {
        timeEvent = GetComponent<TimeEvent>();
        Cursor.visible = false;
        currentGameState = GameState.playing;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Functions
        playerKilled();
        gameStateController();
        
        
        //Set text for timer, kills and current lives
        timerText.text = $"Timer: { Convert.ToInt32(timer)}/ { maxTimer}";
        killsText.text = $"Kills: {kills}";
        if(TheGameManager.instance != null)
        {
            currentLives.text = $"Lives:  {TheGameManager.instance.currentLifes}";
        }
    }
    #endregion

    #region GameFunctions
    public void end()
    {
        SpawnTD spawnTD = GameObject.FindObjectOfType<SpawnTD>();
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");

        spawnTD.enabled = false;
        foreach(GameObject e in enemy)
        {
            Destroy(e);
        }

    }
    public void clock()
    {
        if (timer <= maxTimer)
        {
            timer += Time.deltaTime;

        }
        else
        {
            setState(0);
        }
    }
    public void enemyKilled()
    {
        kills++;
        TopDownShooterAchievements.Instance().ChangeVariable("Kills", 1);
    }
    #endregion

    #region GameStateFunctions
    public void playerKilled()
    {
        if (!player.activeSelf)
        {
            setState(1);
        }
    }

    public void setState(int i)
    {
        currentGameState = (GameState)i;
    }

    public void gameStateController()
    {
        switch(currentGameState)
        {
            case GameState.win:
                {
                    end();
                    timeEvent.Play();
                    break;
                }
            case GameState.lose:
                {
                    TheGameManager.instance.LoseLife();
                    break;
                }
            case GameState.playing:
                {
                    clock();
                    break;
                }
            case GameState.starting:
                {
                    break;
                }
        }
    }
    #endregion
}

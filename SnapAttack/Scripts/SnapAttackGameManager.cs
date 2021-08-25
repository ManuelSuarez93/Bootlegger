using BasicSurvivalKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SnapAttackGameManager : MonoBehaviour
{
    #region Variables
    [Header("UI")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text missedText;
    [SerializeField] private Text currentLifes;
    [Header("Tracking Variables")]
    [SerializeField] private int spawnTotal;
    [SerializeField] private int missedTotal;
    [SerializeField] int totalScore;
    [Header("Clock")]
    [SerializeField] private float GameTimer;
    [SerializeField] private float maxTime;
    [SerializeField] private UnityEvent endEvent;

    [Header("Spawner Controls")]
    [SerializeField] private float inBetweenTime;
    [SerializeField] private float spawnTimer;
    [SerializeField] private SpawnPhotoObj _currentSpawner;

    private int score;
    private int currentmissed;
    private int currentSpawns;
    [SerializeField] private GameState currentGameState;
    #endregion

    #region UnityFunctions
    void Start()
    {
        SetScore(0);
        SetState(2);
        missedText.text = $"Missed: {currentmissed}/{missedTotal}";
        scoreText.text = $"Score {score}/ Min:{totalScore}";
    }

    void Update()
    {
        CheckState();
        gameStateControler();
        if (TheGameManager.instance) { currentLifes.text = "Lives: " + TheGameManager.instance.currentLifes; }

    }
    #endregion

    #region SnapAttackFunctions
    public void Spawn()
    {
        if (spawnTimer <= inBetweenTime)
        {
            spawnTimer += Time.deltaTime;
        }
        else
        {
            if (_currentSpawner.PhotoObj.Length > 1)
            {
                int rand = UnityEngine.Random.Range(0, 3);
                for (int i = 0; i < rand; i++)
                {
                    _currentSpawner.randomizeLocation(1);
                }
            }
            _currentSpawner.randomizeLocation(0);
            currentSpawns++;
            spawnTimer = 0;
        }
    }
    public void SetScore(int i)
    {
        score += i;
        scoreText.text = $"Score {score}/ Min:{totalScore}";
    }
    public void Missed()
    {
        if (currentmissed < missedTotal)
        {
            currentmissed++;
        }
        missedText.text = $"Missed: {currentmissed}/{missedTotal}";
    }
    #endregion

    #region GameStateFunctions
    void CheckState()
    {
        if (currentGameState != GameState.paused && currentGameState != GameState.starting)
        {
            if (currentmissed < missedTotal)
            {
                if (score >= totalScore)
                {
                    SetState(0);
                }
            }
            if(currentmissed >= missedTotal)
            {
                SetState(1);
            }

        }
    }
    void SetState(int i)
    {
        currentGameState = (GameState)i;
    }
    void gameStateControler()
    {
        switch (currentGameState)
        {
            case GameState.playing:
                {
                    Spawn();
                    GameTimer += Time.deltaTime;
                    Cursor.visible = false;
                    break;
                }
            case GameState.win:
                {
                    endEvent.Invoke();
                    Cursor.visible = true;
                    break;
                }
            case GameState.lose:
                {
                    Cursor.visible = true;
                    TheGameManager.instance.LoseLife();
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


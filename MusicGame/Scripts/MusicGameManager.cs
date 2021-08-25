using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MusicGameManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private List<Level> levels;
    
    [Header("UI")]
    [SerializeField] private Text score;
    [SerializeField] private Text failscore;
    [SerializeField] private Image scorefill;
    [SerializeField] private Image failfill;

    [Header("Transition Variables")]
    [SerializeField] private AudioSource mainMusic;
    [SerializeField] private GameObject transitionImage;
    [SerializeField] private float transitionSpeed;
    [SerializeField] private int totalfail;
    [SerializeField] private scoreChange scoreChanged;


    public GameState currentGameState;
    private int currentScore;
    private int currentfail;
    private int currentlevel;
    


    [Serializable]
    public class scoreChange : UnityEvent<int> { }

    [Serializable]
    internal class Level
    {
        public float scoreMax;
        public GameObject levelObject;
        public AudioClip mainMusic;
    }

    #endregion

    #region UnityFunctions
    private void Start()
    {
        currentlevel = 0;
        Cursor.visible = false;
        currentGameState = GameState.playing;
        failscore.text = "Fails: " + currentfail + "/" + totalfail;
    }
   
    private void Update()
    {
        SetUI();
        changeLevel();
        gameStateController();
        checkState();
    }

    #endregion

    #region ChangeLevelFunctions
    void changeLevel()
    {
        if (currentScore > levels[currentlevel].scoreMax )
        {
            if (levels.Count > currentlevel + 1)
            {
                currentScore = 0;
                currentfail = 0;
                currentlevel += 1;
                setLevel(currentlevel);
            }
            else
            {
                currentGameState = GameState.win;
            }
        }
        
    }

    void setLevel(int CurrentLevel)
    {
        transitionImage.GetComponent<Animator>().Play("cosoanimation");
        float t = transitionSpeed;
        print("CurrentLevel" + currentlevel);
        mainMusic.Play();
        StartCoroutine(transition());
    }

    IEnumerator transition()
    {
        mainMusic.clip = levels[currentlevel].mainMusic;
        mainMusic.Play();
        yield return new WaitForSeconds(transitionSpeed);
        for (int i = 0; i < levels.Count; i++)
        {
            if (!(levels[i] == levels[currentlevel]))
            {
                levels[i].levelObject.SetActive(false);
            }
            else
            {
                levels[i].levelObject.SetActive(true);
            }
        }
    }
    #endregion

    #region UIFunctions
    public void SetUI()
    {
        score.text = "Score: " + currentScore;
        scorefill.fillAmount = currentScore / levels[currentlevel].scoreMax;
        failscore.text = "Fails: " + currentfail + "/" + totalfail;
        failfill.fillAmount = (currentfail / totalfail * 1f);
    }
    public void setScore(int i)
    {
        scoreChanged.Invoke(i);
        currentScore += i;
        
    }
    void addFail()
    {
        if(currentfail < totalfail )
        {
            currentfail++; 
        }
    }
    #endregion 

    #region GenericGameStateFunctions
    void checkState()
    {
        if (currentScore < levels[levels.Count-1].scoreMax && currentfail < totalfail && currentGameState != GameState.paused)
        {
            setState(2);
        }
        else if (currentScore < levels[levels.Count - 1].scoreMax && currentfail >= totalfail && currentGameState != GameState.paused)
        {
            setState(1);
        }
        else if (currentScore >= levels[levels.Count - 1].scoreMax && currentfail <= totalfail && currentGameState != GameState.paused)
        {
            setState(0);
        }
    }

    //Seteo el estado del juego
    void setState(int i)
    {
        currentGameState = (GameState)i;
    }

    void waitForTime()
    {
        float wait = 1;
        while (wait > 0)
        {
            wait -= Time.deltaTime;
        }
    }

    //State machine
    void gameStateController()
    {
        switch (currentGameState)
        {
            case GameState.win:
                {
                    TheGameManager.instance.FinishPhase();
                    
                    //Time.timeScale = 0;
                    break;
                }
            case GameState.paused:
                {
                    Time.timeScale = 0;
                    break;
                }
            case GameState.lose:
                {
                    //Time.timeScale = 0; 
                    if (TheGameManager.instance != null) { TheGameManager.instance.LoseLife(); }
                    break;
                }
            case GameState.restart:
                {
                    break;
                }
            case GameState.playing:
                {
                    Time.timeScale = 1;
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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlatformerManager : MonoBehaviour
{
    #region Variables

    public GameState currentGameState;

    [Header("Start/Ending positions")]
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject[] End;
    [SerializeField] private Transform[] LevelStart;
    [SerializeField] private GameObject[] Levels;
   

    [Header("Music")]
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip[] clips;

    private int currentLevel;
    private Vector2 startingPosition;
    #endregion

    #region UnityFunctions
    void Start()
    {
        //Start with first level active
        ActivateLevel(0);
        startingPosition = LevelStart[0].position;
    }
    void Update()
    {
        gameStateController();
    }
    #endregion

    #region PlatformerFunctions
    void ActivateLevel(int i)
    {
        for(int j = 0; j < Levels.Length; j++)
        {
            if(j == i)
            {
                Levels[j].SetActive(true); 

            }
            else
            {
                Levels[j].SetActive(false);
            }
        }
        
    }

    public void PlayerRevive()
    {
        Player.transform.position = LevelStart[currentLevel].position;
        Player.SetActive(true);
        setState(2);
    }
    public void setNextLevel()
    {
        if(currentLevel < Levels.Count() - 1)
        {
            currentLevel++;
            ActivateLevel(currentLevel);
            Player.transform.position = LevelStart[currentLevel].position;
            audioS.clip = clips[currentLevel];
            audioS.Play();
        }
        else
        {
            setState(0);
        }
    }
    #endregion

    #region GameStateFunctions
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
                    if (TheGameManager.instance) { TheGameManager.instance.FinishPhase();};
                    break;
                }
            case GameState.lose:
                {
                    Player.SetActive(false);
                    if (TheGameManager.instance) { TheGameManager.instance.LoseLife(); };
                    PlayerRevive(); 
                    break;
                }
            case GameState.playing:
                {
                    Player.SetActive(true);
                    break;
                }
            case GameState.starting:
                {
                    Player.SetActive(false);
                    break;
                }

        }
    }
    #endregion
}

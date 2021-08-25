using BasicSurvivalKit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombGameManager : MonoBehaviour
{
    #region Variables
    public static BombGameManager instance;
    
    [NonSerialized] public float timer; 
    public float maxTime;
    //--------------
    [Header("UI")]
    [SerializeField] private Text clockTxt;
    [SerializeField] private Image endImgUI;
    [SerializeField] private TimeEvent timeEvent;
    //--------------
    [Header("Bomb Variables")]
    [SerializeField] int max = 4;
    [SerializeField] private List<Image> uiImg;
    [SerializeField] private List<Sprite> imagenes;
    //--------------
    [Header("Check variables")]
    [SerializeField] private List<Sprite> alreadyUsedImg;
    [SerializeField] private List<int> order; 
    [SerializeField] private List<int> currentOrder;
    [SerializeField] private GameState currentGameState;
    #endregion

    #region UnityFunctions(Awake,Start,Update)
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        timer = maxTime;
        InitializeBomb();
    }

    void Update()
    {
        Cursor.visible = false;
        GameStateController();
        CheckOrder();
    }

    #endregion

    #region BombSpecificFunctions
    void Clock()
    {
        timer -=Time.deltaTime;
        clockTxt.text = $":{Convert.ToInt32(timer)}";
        if(timer < 0)
        {
            currentGameState = GameState.lose;
        }
    }

    public void AddToOrder(int or)
    {
        currentOrder.Add(or);
    }

    /// <summary>
    /// Initializes the bomb pieces, in which order are going to be used
    /// </summary>
    void InitializeBomb()
    {
        for (int i = 0; i < uiImg.Count; i++)
        {
            Sprite sprite = null;
            alreadyUsedImg.Add(sprite);
        }

        for (int i = 0; i < uiImg.Count; i++)
        {
            int rand = UnityEngine.Random.Range(0, imagenes.Count);

            while (alreadyUsedImg.Contains(imagenes[rand]))
            {
                rand = UnityEngine.Random.Range(0, imagenes.Count);
            }

            uiImg[i].sprite = imagenes[rand]; 
            alreadyUsedImg[i] = imagenes[rand];
            order.Add(rand);

        }
    }

    /// <summary>
    /// Function to check if order of bomb pieces is correct, and sets game state accordingly
    /// </summary>
    void CheckOrder()
    {
        if(currentOrder.Count > 0 )
        {
            print("Entro al if de current order > 0");
            if (currentOrder.Count < order.Count)
            {
                print("Entro al if de currentOrder.Count < order.Count");
                for (int i = 0; i < currentOrder.Count; i++)
                {
                    print("Entro al for de count menor a order count");
                    print("Dentro del For: " + i);
                    if (currentOrder[i] != order[i])
                    {
                        print("Entro al if de si el current order es diferente");
                        currentGameState = GameState.lose;
                    }
                }
            }
            else
            {
                for (int i = 0; i < currentOrder.Count - 1; i++)
                {
                    if (currentOrder[i] != order[i])
                    {
                        currentGameState = GameState.lose;
                    }
                }
                currentGameState = GameState.win;

            }
        }
    }
    #endregion

    #region GenericGameStateController
    public void SetState(int i)
    {
        currentGameState = (GameState)i;
    }

    public void GameStateController()
    {
        switch(currentGameState) 
        {
            case GameState.win:
                {
                    if(timer <= 5) { BombAchievements.Instance().ChangeVariable("Defuser", true); }
                    timer = 0;
                    timeEvent.Play();
                    break;
                }
            case GameState.lose:
                {
                    timer = 0;
                    if (TheGameManager.instance) { TheGameManager.instance.LoseLife(); };
                    break;
                }
            case GameState.playing:
                {
                    Clock(); 
                    break;
                }
            case GameState.paused:
                {
                    Time.timeScale = 0;
                    break;
                }
            case GameState.starting:
                {
                    clockTxt.text = "";
                    break;
                }
            default: break;
        }
        
    }
    #endregion
}

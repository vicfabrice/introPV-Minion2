using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using System.Collections.Generic;       //Allows us to use Lists. 

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    private BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.
    private int level = 3;                                  //Current level number, expressed in game as "Day 1".
    private int lives = 5;
    private int initialLives = 10;

    public static GameState CurrentGameState = GameState.Start;

    public static int score = 0;
    public static int blocksAlive = 39;

    public static BallScript Ball;
    private GameObject[] bricks;

    public static Text statusText;

    //Awake is always called before any Start functions
    void Awake()
    {
        
        //Chequea si la instancia existe o no 
        if (instance == null)

            //si es no, la setea
            instance = this;

        //si si, la destruye 
        else if (instance != this)

            
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //##Get a component reference to the attached BoardManager script
        //boardScript = GetComponent<BoardManager>();

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    void Start()
    {
        bricks = GameObject.FindGameObjectsWithTag("Brick");
        GameObject BallTemp = GameObject.Find("Ball");
        Ball = BallTemp.GetComponent<BallScript>();
        statusText = GameObject.Find("Status").GetComponent<Text>();
    }

    private bool InputTaken()
    {
        return Input.touchCount > 0 || Input.GetButtonDown("Jump");
    }

    //Initializes the game for each level.
    void InitGame()
    {
        //Call the SetupScene function of the BoardManager script, pass it current level number.
        //### boardScript.SetupScene(level);
        this.lives = 9;

    }

    public static void DecreaseLives()
    {
        instance.lives--;
    }

    //Update is called every frame.
    void Update()
    {
        switch (CurrentGameState)
        {
            case GameState.Start:
                Debug.Log("ok");
                if (InputTaken())
                {
                    statusText.text = string.Format("Blocks restantes: {0}  Score: {1}", blocksAlive, score);
                    CurrentGameState = GameState.Playing;
                    Ball.StartBall();
                }
                break;
            case GameState.Playing:
                break;
            case GameState.Won:
                if (InputTaken())
                {
                    Restart();
                    Ball.StartBall();
                    statusText.text = string.Format("Lives: {0}  Score: {1}", lives, score);
                    CurrentGameState = GameState.Playing;
                }
                break;
            case GameState.LostALife:
                if (InputTaken())
                {
                    Ball.StartBall();
                    statusText.text = string.Format("Lives: {0}  Score: {1}", lives, score);
                    CurrentGameState = GameState.Playing;
                }
                break;
            case GameState.LostAllLives:
                if (InputTaken())
                {
                    Restart();
                    Ball.StartBall();
                    statusText.text = string.Format("Lives: {0}  Score: {1}", lives, score);
                    CurrentGameState = GameState.Playing;
                }
                break;
            default:
                break;
        }
    }

    private void Restart()
    {
        foreach (var item in bricks)
        {
            item.SetActive(true);
            //item.GetComponent<BrickScript>().InitializeColor();
        }
        lives = 3;
        score = 0;
    }

    public static int GetLives()
    {
        return instance.lives;
    }

    public enum GameState
    {
        Start,
        Playing,
        Won,
        LostALife,
        LostAllLives
    }
}
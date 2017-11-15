using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

using System.Collections.Generic;       //Para listas

public class GameManager : MonoBehaviour
{

    Text statusText; //el texto que se va a visualizar en el juego

    public static GameManager instance = null;
    public static GameState CurrentGameState = GameState.Start;
    //private BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.
    public static int level = 1;                                  //Current level number, expressed in game as "Day 1".
    public static int lives = 3;
    public static int score = 0;
    public static int blocksAlive = 39;

    public static BallScript Ball;
    private GameObject[] bricks;

    void Start()
    {
        bricks = GameObject.FindGameObjectsWithTag("Brick");
        blocksAlive = bricks.Length;
        Ball = GameObject.Find("Ball").GetComponent<BallScript>();
        statusText = GameObject.Find("Status").GetComponent<Text>();
    }

    //como tomo el input
    private bool InputTaken()
    {
        return Input.touchCount > 0 || Input.GetButtonDown("Jump");
    }
   
    //Update is called every frame.
    void Update()
    {
        switch (CurrentGameState)
        {
            case GameState.Start:
                Debug.Log("ok");
                //statusText.text = string.Format("Score: {0}  Vidas:{1}", score, lives);
                if (InputTaken())
                {
                    CurrentGameState = GameState.Playing;
                    Ball.StartBall();
                }
                break;
            case GameState.Playing:
                statusText.text = string.Format("Score: {0}  Vidas:{1}  Estado:{2}", score, lives, CurrentGameState);
                if (blocksAlive == 0)
                {
                    CurrentGameState = GameState.Won;
                }
                break;
            case GameState.Won:
                statusText.text = string.Format("GANASTE Campeón. Si querés jugar otra vez, tap tap tap");
                //Ball.StopBall();
                if (InputTaken())
                {
                    Ball.StartBall();
                    Restart();
                    //Ball.StartBall();
                    CurrentGameState = GameState.Start;
                    Debug.Log("estado:" + GameManager.CurrentGameState);
                    statusText.text = string.Format("Lives: {0}  Score: {1}", lives, score);
                    //CurrentGameState = GameState.Start;
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
            item.SendMessage("resetHealth");
        }
        lives = 3;
        score = 0;
    }        
    
    public void DecreaseLives()
    {
        if (lives > 0)
            lives--;

        if (lives == 0)
        {
            statusText.text = "Perdiste todas las vidas papá. Tap para jugar otra vez";
            CurrentGameState = GameState.LostAllLives;
        }
        else
        {
            statusText.text = "Perdiste una vida. Tap para continuar";
            CurrentGameState = GameState.LostALife;
        }
        Ball.StopBall();
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
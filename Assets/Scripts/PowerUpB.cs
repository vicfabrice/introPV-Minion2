using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpB: MonoBehaviour {

    public int health;
    private int baseHealth;
    public float speedBonus;
    public int livesBonus;

    // Use this for initialization
    void Start () {
        baseHealth = health;
        livesBonus = 3;
        speedBonus = 8f;
    }

    void resetHealth()
    {
        health = baseHealth;

    }
    // Update is called once per frame
    void Update () {
	    
	}

    void OnTriggerEnter2D(Collision2D col)
    {
        this.health--;

        if (col.gameObject.tag == "Ball")
        {
            GameManager.Ball.SpeedY = 1f;
            gameObject.SetActive(false);
            GameManager.blocksAlive--;
            Debug.Log("soy un powerUp");
            GameManager.score += 100;
            GameManager.lives += 1;
        }
    }
}

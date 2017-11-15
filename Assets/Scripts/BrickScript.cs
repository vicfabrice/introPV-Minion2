using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickScript : MonoBehaviour {

    public int health;
    private int baseHealth;
    Image img;

	// Use this for initialization
	void Start () {

        baseHealth = health;
        img = GetComponent<Image>();

    }

    void resetHealth()
    {
        health = baseHealth;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnCollisionExit2D(Collision2D col){

        this.health--;

        if (this.health == 1)
        {
            img.color = new Color(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f));
            //gameObject.GetComponent<Image>().color = new Color32(255, 255, 225, 100);
            //GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f));
        }

        if (this.health == 0)
        {
            gameObject.SetActive(false);
            GameManager.score += 15;
            GameManager.blocksAlive--;
            //GameManager.statusText.text = string.Format("Blocks restantes: {0}  Score: {1}", GameManager.blocksAlive, GameManager.score);
            Debug.Log("score =" + GameManager.score + " blocksAlive =" + GameManager.blocksAlive + " lives =" + GameManager.lives);
        }
    }
}

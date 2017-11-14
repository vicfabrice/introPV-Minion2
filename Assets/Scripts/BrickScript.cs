using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {

    public int health = 3;

	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionExit2D(Collision2D col){

            this.health--;

        if (this.health == 0)
        {
            gameObject.SetActive(false);
            GameManager.score += 15;
            GameManager.blocksAlive--;
            GameManager.statusText.text = string.Format("Blocks restantes: {0}  Score: {1}", GameManager.blocksAlive, GameManager.score);
            Debug.Log("score =" + GameManager.score + " blocksAlive =" + GameManager.blocksAlive);
        }
    }
}

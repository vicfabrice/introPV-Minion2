using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour {

    //le paso el GM 
    public GameManager gameManager;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            gameManager.DecreaseLives();
            Debug.Log("ahora son " + GameManager.lives);

        }
    }
}

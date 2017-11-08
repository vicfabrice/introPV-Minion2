using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    //la velocidad o fuerza de la bola
    float BallForce = 350f;
    public Rigidbody2D rbBall;

	// Use this for initialization
	void Start () {

        // Rigidbody2D rbBall = GetComponent<Rigidbody2D>();
        //rbBall.AddForce(new Vector2(0, BallForce));
	}



    // Update is called once per frame
    void Update () {
		
	}
}

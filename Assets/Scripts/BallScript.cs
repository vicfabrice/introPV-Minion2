using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    //la velocidad o fuerza de la bola
    public float ballForce = 350f;
    public float SpeedY = 7;
    public Rigidbody2D rbBall;
    private Vector2 InitialLocation;

  

    // Use this for initialization
    void Start () {

        InitialLocation = transform.position;
        // Rigidbody2D rbBall = GetComponent<Rigidbody2D>();
        //rbBall.AddForce(new Vector2(0, BallForce));
    }



    // Update is called once per frame
    void Update () {
		
	}

    public void StartBall()
    {
        transform.position = InitialLocation;
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3.0f, 3.0f), SpeedY);
    }

 

    public void StopBall()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public float GetBallForce()
    {
        return this.ballForce;
    }
}

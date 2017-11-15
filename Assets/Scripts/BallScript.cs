using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallScript : MonoBehaviour
{

    //la velocidad de la bola
    public float SpeedY = 2;
    private Vector3 InitialLocation;
    public static PowerUpB PowerUpBrick;


    // Use this for initialization
    void Start()
    {

        //PowerUpBrick = GameObject.Find("PowerUp").GetComponent<PowerUpB>();
        InitialLocation = transform.position;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero; //vel. al empezar
        SpeedY = 3;
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.CurrentGameState == GameManager.GameState.Playing)
            GiveBoostIfMovingOnXorYAxis();

    }

    private void GiveBoostIfMovingOnXorYAxis()
    {
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x - 0.2f) <= 0.2f)
        {
            //derecha o izquierda
            bool right = Random.Range(-1.0f, 1.0f) >= 0;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(right ? 5.0f : -5.0f, 0), ForceMode2D.Impulse);
        }

        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y - 0.2f) <= 0.2f)
        {
            //arriba o abajo 
            bool down = Random.Range(-1.0f, 1.0f) >= 0;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, down ? 5.0f : -5.0f), ForceMode2D.Impulse);
        }
    }

    public void StartBall()
    {
        transform.position = InitialLocation;
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3.0f, 3.0f), SpeedY);
    }

    public void StopBall()
    {
        //pongo la velocidad en cero como en el comienzo
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PowerUp")
        {
            PowerUpBrick = col.gameObject.GetComponent<PowerUpB>();
            SpeedY += PowerUpBrick.speedBonus;
            GameManager.lives += PowerUpBrick.livesBonus;
            PowerUpBrick.gameObject.SetActive(false);
            Debug.Log("powerup");
        }
    }
}

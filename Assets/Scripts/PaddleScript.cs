using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

    //velocidad del palito
    public float speed = 10f;
    private Vector3 paddlePosition;
    public float limites;

    // Use this for initialization
    void Start() {

        // get the initial position of the game object
        restartPaddle();

    }

    void restartPaddle()
    {
        paddlePosition = gameObject.transform.position;
    }
    
    // Update is called once per frame
    void Update() {

        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * speed);
        var pos = transform.position;
        pos.x = Mathf.Clamp(xPos, -5.5f, 5.5f);
        transform.position = pos;

        if (Input.GetButtonDown("Jump"))
        {
            GameManager.Ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, GameManager.Ball.SpeedY));
        }
        // leave the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


    }

}

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.collider == GetComponent<BoxCollider2D>())
            {
                float calc = contact.point.x - transform.position.x;
                contact.otherCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(200 * calc, 0));
            }
        }
    }*/

    

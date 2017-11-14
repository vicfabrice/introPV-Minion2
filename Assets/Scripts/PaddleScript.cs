using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

    //velocidad del palito
    public float paddleSpeed = 10f;
    
    public Transform TheCanvas;
    

    

    // Use this for initialization
    void Start() {
        
    }

    
    // Update is called once per frame
    
    void Update() {

        // transform.Translate(paddleSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);
        //Todo esto de abajo para que la barrita no se vaya del juego
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        var pos = transform.position;
        pos.x = Mathf.Clamp(xPos, -5.5f, 5.5f);
        transform.position = pos;

        if (Input.GetButtonDown("Jump"))
         {
                GameManager.Ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, GameManager.Ball.SpeedY));
         }
        
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.collider == GetComponent<BoxCollider2D>())
            {
                float calc = contact.point.x - transform.position.x;
                contact.otherCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(200 * calc, 0));
            }
        }
    }
}

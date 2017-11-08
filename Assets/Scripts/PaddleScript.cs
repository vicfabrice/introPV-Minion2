using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

    //velocidad del palito
    public float paddleSpeed = 10f;
    public GameObject ballPrefab;
    public Transform TheCanvas;
    public GameObject newBall = null;

    public float ballForce = 300f;

	// Use this for initialization
	void Start () {
        SpawnBall();
	}

    void SpawnBall()
    {
        if(ballPrefab == null)
        {
            Debug.Log("add ballprefab");
            return;
        }

        Vector3 ballPosition = transform.position + new Vector3(0, 0.5f, 0);
        newBall = Instantiate(ballPrefab,ballPosition,Quaternion.identity) as GameObject;
        newBall.transform.SetParent(TheCanvas);
        newBall.transform.localScale = new Vector3(100f, 100f, 0);
    }
    // Update is called once per frame
    // Quiero que el palito se mueva de izquiera a derecha y viceversa
    void Update() {

        // transform.Translate(paddleSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);
        //Todo esto de abajo para que la barrita no se vaya del juego
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        var pos = transform.position;
        pos.x = Mathf.Clamp(xPos, -5.5f, 5.5f);
        transform.position = pos;

        if (Input.GetButtonDown("Jump"))
        {
            if (newBall)
            {
                newBall.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, ballForce));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(ContactPoint2D contact in collision.contacts)
        {
            if (contact.collider == GetComponent<BoxCollider2D>())
            {
                float calc = contact.point.x - transform.position.x;
                contact.otherCollider.GetComponent<Rigidbody2D>().AddForce(new Vector2(ballForce* calc,0));
            }
        }
    }
}

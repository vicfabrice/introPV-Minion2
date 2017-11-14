using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour {

    
    
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ball")
        {
            GameManager.DecreaseLives();
            Debug.Log("ahora son " + GameManager.GetLives());
            
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

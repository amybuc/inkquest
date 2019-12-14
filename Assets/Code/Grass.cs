using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Grass_collision detected!");

        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Grass_collision from player detected!");
            gameObject.GetComponent<Animator>().SetTrigger("Rustle");

        }
    }
}

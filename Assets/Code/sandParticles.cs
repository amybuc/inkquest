using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandParticles : MonoBehaviour {

	public Transform player;
	Animator playeranimator;

	// Use this for initialization
	void Start ()
	{

		playeranimator = player.gameObject.GetComponentInChildren<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

		gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y-75, transform.position.z);

		
		if (playeranimator.GetBool("moving") == true)
		{
			gameObject.GetComponent<ParticleSystem>().enableEmission = true;
		}
		else
		{
			gameObject.GetComponent<ParticleSystem>().enableEmission = false;
		}

	}
}

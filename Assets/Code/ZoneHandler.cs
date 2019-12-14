using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneHandler : MonoBehaviour {

    public string zoneName;

    public UIHandler UIhandler;

	// Use this for initialization
	void Start () {
        UIhandler = GameObject.Find("GameController").GetComponent<UIHandler>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            UIhandler.ShowNotification("Entering " + zoneName);
        }
    }
}

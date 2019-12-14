using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSortingOrder : MonoBehaviour {

    [SerializeField]
    private int SortingOrderBase = 5000;
    [SerializeField]
    private int offset = 0;
    [SerializeField]
    private bool runOnlyOnce = false;
    [SerializeField]
    private bool isGrass;

    private float timer;
    private float timermax = 0.1f;
    private Renderer myRenderer;

    private void Awake()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            timer = timermax;
            myRenderer.sortingOrder = (int)(SortingOrderBase - transform.position.y - offset);
            if (isGrass)
            {
                myRenderer.sortingOrder -= 1000;
            }
            if (runOnlyOnce)
            {
                Destroy(this);
            }
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

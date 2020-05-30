using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    public Vector3 change;

    public bool moveLocked = false;
    public bool interactableInRange;
    public GameObject interactable;
    public GameObject mainCanvas;
    public Animator playeranimator;

    public float controlY;
    public float controlX;

    //public Rigidbody2D rb;

    public List<Item> inventory;
    public int playerCoins;


    //NEW MOVEMENT
    Rigidbody2D rb;

    public bool isBusy;

    public void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        //Give Player 50 coins for debugging
        playerCoins = 50;


    }

    public void Update()
    {

        #region Movement
        /*
        controlY = Input.GetAxis("Vertical");
        controlX = Input.GetAxis("Horizontal");

        //Set Animaiton
        if (controlY == 0 && controlX == 0)
        {
            playeranimator.Play("player_art");
        }

        if (controlY > 0)
        {
            playeranimator.Play("Art_char_walk_backwards");
        }
        else if (controlY < 0)
        {
            playeranimator.Play("Art_char_walk_forward");
        }
        else if (controlX > 0)
        {
            playeranimator.Play("Art_char_walk_right");
        }
        else if (controlX < 0)
        {
            playeranimator.Play("Art_char_walk_left");
        }




        if (Input.GetAxisRaw("Horizontal") > 0.5 || Input.GetAxisRaw("Horizontal") < -0.5)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
        }
        */

        /*
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);
        */


        /*
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        // Returns a copy of vector with its magnitude clamped to maxLength
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        // Transforms direction from local space to world space.
        movement = transform.TransformDirection(movement);
        rb.AddForce(movement);

*/
        #endregion

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (!isBusy)
        {
            UpdateAnimationAndMove();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {

			if (interactableInRange == true)
            {
				if (interactable.tag == "NPC")
                {
					GameObject.Find("GameController").GetComponent<Dialogue>().Speak(interactable.gameObject);
                    mainCanvas.SetActive(false);
                }
                if (interactable.tag == "TOWN")
                {
                    interactable.GetComponent<Town>().openTownMenu();
                    interactable.GetComponent<Town>().setUpTownUIButtons();
                    mainCanvas.SetActive(false);

					/*

                    if (interactable.GetComponent<Town>().activeState[0].stateName == null)
                    {
                        Debug.Log("Player :: The town " + interactable.GetComponent<Town>().townName + " does not have an active state");
                    }
                    else
                    {
                        Debug.Log("The active state on" + interactable.GetComponent<Town>().townName + " has an active state of " + interactable.GetComponent<Town>().activeState[0].stateName);
                    }

					*/

                }
            }
        }


    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            playeranimator.SetFloat("moveX", change.x);
            playeranimator.SetFloat("moveY", change.y);
            playeranimator.SetBool("moving", true);
        }
        else
        {
            playeranimator.SetBool("moving", false);
        }
    }

    public void MoveCharacter()
    {
        rb.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "NPC")
        {
			interactableInRange = true;
            interactable = collision.gameObject;
        }
        if (collision.gameObject.tag == "TOWN")
        {
            interactableInRange = true;
            interactable = collision.gameObject;

        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        interactableInRange = false;
        interactable = null;
    }
}

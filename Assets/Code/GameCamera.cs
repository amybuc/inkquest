using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

    public Transform player;
    public float m_speed = 0.1f;
    Camera mycam;
    public bool isDialogue = false;
    //public Vector3 offset; // 750 was good

    private void Start()
    {
        mycam = GetComponent<Camera>();
    }

    void Update()
    {
        if (player)
        {
            if (!isDialogue)
            {
                transform.position = Vector3.Lerp(transform.position, player.position, m_speed) + new Vector3(0, 0, -75);
            }
            else if (isDialogue)
            {
                transform.position = Vector3.Lerp(transform.position, player.position, m_speed) + new Vector3(0, -10, -45);
            }

        }
        //transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position
    }

}

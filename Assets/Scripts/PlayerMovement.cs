using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour {

    //NOTE: MISSING ANIMATIONS
    //Good reference on how to add in player animations: https://www.youtube.com/watch?v=TU6wflRqT5Q&t=238s   https://www.youtube.com/watch?v=Tm2L-_0eIeY&t=629s

    public float moveSpeed;
    private Rigidbody2D playerRB;


    // Use this for initialization
    void Start () {
        playerRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        //Get motion input from users
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");

        //player movement 
        bool isMoving = false;
        if (Mathf.Abs(input_x) + Mathf.Abs(input_y) > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        //Move the character and do animations
        if (isMoving)
        {
            //transform.position += new Vector3(input_x, input_y, 0).normalized * Time.deltaTime * moveSpeed;
            playerRB.velocity = new Vector2(input_x * moveSpeed, input_y * moveSpeed);
        }
        else
        {
            playerRB.velocity = new Vector2(0, 0);
        }

        //player X button?
    }
}
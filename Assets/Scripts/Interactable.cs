using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    //good ref:https://www.youtube.com/watch?v=9tePzyL6dgc&t=87s

    public float interactionRadius = 0.55f; //radius that the player needs to enter in order to interact with an object
    public Transform player; //get player's game object (set within unity)
    private bool inRange = false; //bool to set true if the player is within the interaction radius

    //gizmons to see radius 
    private void OnDrawGizmosSelected()
    {
        if (player == null)
        {
            player = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

    //check if the player is in range
    void Update()
    {
        //get the distance from the player and the interactable (interactable set within unity)
        float distanceFromTarget = Vector3.Distance(player.position, transform.position);
        //check if the player is in range
        if (distanceFromTarget <= interactionRadius)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        //check if the player has interacted with the object
        if (inRange)
        { 
            //NEED: PROMPT PLAYER TO INTERACT WITH OBJECT

            if (Input.GetKeyDown("space"))
            {
                Debug.Log("interacted");
                Interact();
            }
			if (Input.GetKeyDown ("space")) 
			{
				Debug.Log ("  ^   ^  \n <(o . o)>\nNothing to interact with");
			}
        }
    }

    //player does something with the interactable (can be replaced)
    public virtual void Interact()
    {
    }

}

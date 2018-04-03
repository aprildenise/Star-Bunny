using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class NPC : Interactable {

	//Initialize NPC to this variable
	public Item friend;

	// Use this for initialization
	public override void Interact() {
		base.Interact();
		//talk is only function but more can be added on
		TalkNPC ();
	}
	
	// Update is called once per frame
	void TalkNPC () {
		//get dialogue based on the friend item in the future
		Debug.Log ("Hello Friend!");
	}
}

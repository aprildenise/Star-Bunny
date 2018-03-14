using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable {

    //good ref:https://www.youtube.com/watch?v=HQNl3Ff2Lpo

    public Item item; //what item is it? (scriptable object) (set within unity)

    public override void Interact()
    {
        base.Interact();
        PickupItem();
    }

    //allow the player to interact with items on the ground and pick them up
    void PickupItem()
    {
        Debug.Log("picking up " + item.itemType.name);
        bool addedToInventory = Inventory.instance.Add(item); //add the item into the inventory instance
        if (addedToInventory)
        {
            Destroy(gameObject);
        }
    }

}

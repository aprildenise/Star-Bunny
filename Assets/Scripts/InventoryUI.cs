using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Note: delegates are no longer needed and commented out

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent; //container that holds all the inventory slots (set within unity)
    Inventory inventory; //inventory instance
    InventorySlot[] slots; //array for all the inventory slots
    public GameObject inventoryUI; //game object of the inventory, used for toggling the inventory screen (set within unity)


	// Use this for initialization
	void Start () {

        inventory = Inventory.instance; //initialization from the singleton
        inventory.onInventoryChangedCallback += UpdateUI; //add updateUI to the delegate of inventory
        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); //find all objects that have an InventorySlot component within the itemsParent object and store it in the slots array
        //InitializeInventoryUI();
    }


    void InitializeInventoryUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].ClearSlot();
        }
    }


	
	// Update is called once per frame
	void Update () {
		//check if the player hit the inventory key
        if (Input.GetButtonDown("Inventory"))
        {
            Debug.Log("hit inventory key");
            //close or open the UI, dependng if its already open or closed
            inventoryUI.SetActive(!inventoryUI.activeSelf);


            if (inventoryUI.activeSelf)
            {
                Time.timeScale = 0f;
                //every time the inventory is openned, the first inventory slot should be selected
                if (inventory.items.Count > 0)
                {
                    slots[0].button.Select();
                }
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
	}
    

    
    //add a new item to the inventory UI
    void UpdateUI(int indexFromInventory)
    {
        //loop through to find an empty slot in the InventorySlots array
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].hasItem == false)
            {
                //add item to this slot
                slots[i].AddToSlot(inventory.items[indexFromInventory]);
                Debug.Log("Updating new item in inventory UI");
                return;
            }
        }
    }
    


    /*
    //No longer used. uses delegates. so uncomment them if this is needed again
    
    void UpdateUI()
    {
        Debug.Log("updating UI");
        //loop through the slots array to add/clear items to the inventory UI
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count) //if there are more items that need to be added to the inventory UI
            {
                slots[i].AddToSlot(inventory.items[i]); //add the item to the inventory UI slot
            }
            else
            {
                slots[i].ClearSlot(); //clear the slot/make it empty
            }
        }
    }
    */
}

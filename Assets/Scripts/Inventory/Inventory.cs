using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Note: delegates are no longer needed and commented out
//**Need to error check if stack is over a certain limit

public class Inventory : MonoBehaviour {

    //good reference: https://www.youtube.com/watch?v=HQNl3Ff2Lpo

    //singleton pattern to make sure there is only one instance of the inventory (only one inventory)
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of Inventory found!!");
            return;
        }
        instance = this;
    }

    
    //delegate for inventory object
    public delegate void OnInventoryChanged(int index);
    public OnInventoryChanged onInventoryChangedCallback;
    

    public InventoryUI UI; //InventoryUI (set within Unity??)
    public List<Item> items = new List<Item>(); //list of items used for the inventory
    public int maxItems = 21; //max number of items

    //add an item to the inventory
    public bool Add(Item item)
    {
        
        //check if the item already exists in the inventory to stack it
        int index = SearchInventory(item);
        if (index != -1)
        {
            //stack the item by adding it to the item's count
            items[index].itemCount++;
            Debug.Log(item.itemType.name + " added to inventory (dup)." + "Has " + item.itemCount);
            return true;
        }
        //there is no dup in the inventory. add the new item to the inventory
        else
        {
        
            //check if there is enough space in inventory to add
            if (items.Count >= maxItems)
            {
                Debug.Log("No room in the inventory");
                return false;
            }
            else
            {
                items.Add(item);//add item to the list
                //UI.UpdateNewItem(items.Count);//update UI by sending in the index of the item in the inventory list, which is the last index in the list
                
                
                //delegates
                if (onInventoryChangedCallback != null)
                {
                    onInventoryChangedCallback.Invoke(items.Count - 1);
                }
                
                
                Debug.Log(item.name + " added to inventory");
                return true;
            }
        }
    }

    //remove an item from the inventory 
    //Note: removes ALL stacks of that item
    public bool Remove(Item item)
    {
        items.Remove(item);

        /*
        //delegates
        if (onInventoryChangedCallback != null)
        {
            onInventoryChangedCallback.Invoke();
        }
        */

        return true;
    }

    //change number of max items
    public void IncreaseInventory(int newSize)
    {
        maxItems = newSize;

        /*
        //delegates
        if (onInventoryChangedCallback != null)
        {
            onInventoryChangedCallback.Invoke();
        }
        */
    }

    //seach inventory list for a specific item and returns the index of that item or -1 if it does not exist
    int SearchInventory(Item item)
    {
        if (items.Count == 0)
        {
            return -1;
        }
        for (int i = 0; i < items.Count; i++)
        {
            if (item.itemType.name == items[i].itemType.name) //if there exists the same items already in the inventory
            {
                return i;
            }
        }
        return -1;
    }

}

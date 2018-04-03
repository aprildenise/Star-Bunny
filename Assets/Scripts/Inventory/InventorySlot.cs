using UnityEngine;
using UnityEngine.UI; //IMPORTANT 


//**OnRemoveButton needs to be changed; because the remove button will not be on the inventory slot. instead, we want a hold button

public class InventorySlot : MonoBehaviour {


    Item item; //current item in the slot
    public Image icon; //icon of the item
    public Button button; //button component attached to the slot (set within unity)
    public bool hasItem; //if there is an item in the slot 
    public Text count; //the number of items in that slot, in string form

    public void AddToSlot(Item newItem)
    {
        item = newItem;
        icon.sprite = item.itemType.icon;
        icon.enabled = true;
        button.interactable = true;

        hasItem = true;
    }


    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;

        button.interactable = false;

        count.enabled = false;
        count.text = null;

        hasItem = false;
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.itemType.Use();
        }
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
        ClearSlot();
    }

    void UpdateItemCount()
    {
        if (item.itemCount > 1)
        {
            count.enabled = true;
            count.text = item.itemCount.ToString();
            Debug.Log("updating item count");
        }
    }

    private void Update()
    {
        if (item != null)
        {
            UpdateItemCount();
        }
    }

}

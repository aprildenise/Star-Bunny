using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Type", menuName = "Item Type")]
public class ItemType : ScriptableObject
{

    new public string name = "item"; //name of the item
    public Sprite icon = null; //sprite for the item
    public int itemCount = 0; //number of items (the same items stack onto one item object)
    //more to come

    public virtual void Use()
    {
        Debug.Log("using" + name);
    }

}

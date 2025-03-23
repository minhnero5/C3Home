using System;
using UnityEngine;
[Serializable]
public class ItemInventory  
{
    public string itemID;
    public ItemProfileSO itemProfileSO;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;

    public virtual ItemInventory Clone()
    {
        ItemInventory item = new ItemInventory
        {
            itemID = ItemInventory.RandomID(),
            itemProfileSO = this.itemProfileSO,
            itemCount = this.itemCount,
            upgradeLevel = this.upgradeLevel
        };
        return item;
    }

    public static string RandomID()
    {
        return RandomStringGenerator.Generate(10);
    }
}

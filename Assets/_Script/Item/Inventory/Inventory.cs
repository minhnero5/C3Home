using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : ThanguMonoBehavior
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;

    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.IronOre, 3);
    }

    public virtual bool AddItem(ItemCode itemCode,int addCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);

        int newCount = itemInventory.itemCount + addCount;
        if (newCount > itemInventory.maxStack) return false;
        itemInventory.itemCount = newCount;
        return true;
    }

    protected virtual ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find((item) => item.itemProfileSO.itemCode == itemCode);
        if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
        return itemInventory;

    }

    protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("ItemProfiles", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            ItemInventory itemInventory = new ItemInventory
            {
                itemProfileSO = profile,
                maxStack = profile.defaultMaxStack
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }

        return null;
    }
}

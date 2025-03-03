using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropTest : ThanguMonoBehavior
{
    public JunkController junkController;
    public int dropCount = 0;
    public List<ItemDropCount> dropCountItems = new List<ItemDropCount>();

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(this.Dropping), 2, 0.5f);
    }

    protected virtual void Dropping()
    {
        this.dropCount++; 
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        List<ItemDropRate> dropItems = ItemDropSpawner.Instance.Drop(this.junkController.ShootableObject.dropList, dropPos, dropRot);
        ItemDropCount itemDropCount;
        foreach (ItemDropRate itemDropRate in dropItems)
        {
            itemDropCount = this.dropCountItems.Find(i => i.itemName == itemDropRate.itemProfileSO.itemName);
            if(itemDropCount == null)
            {
                itemDropCount = new ItemDropCount();
                itemDropCount.itemName = itemDropRate.itemProfileSO.itemName;
                this.dropCountItems.Add(itemDropCount);
            }

            itemDropCount.count += 1;
            itemDropCount.rate = (float)Math.Round((float)itemDropCount.count / this.dropCount, 2) ;
        }
    }
}

[Serializable]
public class ItemDropCount
{
    public string itemName;
    public int count;
    public float rate;
}


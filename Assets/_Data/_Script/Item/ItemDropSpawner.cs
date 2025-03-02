using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    [SerializeField] protected float gameDropRate=1;
    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner.instance != null) Debug.LogError("Only 1 DropManager allow");
        ItemDropSpawner.instance = this;
    }

    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList,Vector3 pos, Quaternion rot)
    {
        List<ItemDropRate> dropItems = new List<ItemDropRate>();
        if (dropList.Count < 1) return dropItems;
         dropItems = this.DropItem(dropList);

        foreach (ItemDropRate itemDropItem in dropItems)
        {
            ItemCode itemCode = itemDropItem.itemProfileSO.itemCode;
            Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
            if (itemDrop == null) continue;
            itemDrop.gameObject.SetActive(true);
        }

        return dropItems;
    }

    protected virtual List<ItemDropRate> DropItem(List<ItemDropRate> items)
    {
        List<ItemDropRate> droppedItems=new List<ItemDropRate>();
        float rate,itemRate;

        foreach (ItemDropRate item in items)
        {
            rate = Random.Range(0, 1f);
            itemRate = item.dropRate * this.gameDropRate;
            if (rate<=itemRate)
            {
                droppedItems.Add(item);
            }
        }
        return droppedItems;
    }

    public virtual Transform DropFromInventory(ItemInventory itemInventory, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = itemInventory.itemProfileSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if (itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);
        ItemController itemController = itemDrop.GetComponent<ItemController>();
        itemController.SetItemInventory(itemInventory);
        return itemDrop;
    }
}

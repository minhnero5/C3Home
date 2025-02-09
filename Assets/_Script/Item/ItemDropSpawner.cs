using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner.instance != null) Debug.LogError("Only 1 DropManager allow");
        ItemDropSpawner.instance = this;
    }

    public virtual void Drop(List<DropRate> dropList,Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = dropList[0].itemProfileSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }

    public virtual Transform Drop(ItemInventory itemInventory, Vector3 pos, Quaternion rot)
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

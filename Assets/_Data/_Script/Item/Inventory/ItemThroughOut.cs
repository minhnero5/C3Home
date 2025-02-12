using Unity.Mathematics;
using UnityEngine;

public class ItemThroughOut : InventoryAbstract
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.Test), 5);
    }

    protected virtual void Test()
    {

        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        this.DropItemIndex(0,dropPos,transform.rotation);
    }

    protected virtual void DropItemIndex(int indexItem,Vector3 dropPos,quaternion dropRot)
    {
        ItemInventory itemInventory = this.inventory.Items[indexItem];

        ItemDropSpawner.Instance.Drop(itemInventory, dropPos, transform.rotation);
        this.inventory.Items.Remove(itemInventory);
    }
}

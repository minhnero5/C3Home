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
        this.DropItemIndex(0);
    }

    protected virtual void DropItemIndex(int indexItem)
    {
        ItemInventory itemInventory = this.inventory.Items[indexItem];

        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        ItemDropSpawner.Instance.Drop(itemInventory, dropPos, transform.rotation);
    }
}

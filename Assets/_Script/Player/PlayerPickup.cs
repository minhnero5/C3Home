using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        ItemCode itemCode = itemPickupable.GetItemCode();
        if(this.controller.CurrentShip.Inventory.AddItem(itemCode,1))
        {
            itemPickupable.Picked();
        }
    }
}

using UnityEngine;

public class ItemDropTest : ThanguMonoBehavior
{
    public JunkController junkController;

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(this.Dropping), 2, 0.5f);
    }

    protected virtual void Dropping()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkController.ShootableObject.dropList, dropPos, dropRot);
    }
}

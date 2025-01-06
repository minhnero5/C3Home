using UnityEngine;

public class FXDespawn : DespawnByTIme
{
    public override void DespawnObject()
    {
        FXSpawner.Instance.Despawn(transform.parent);
    }
}

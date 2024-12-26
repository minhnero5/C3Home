using UnityEngine;

public abstract class DeSpawn : ThanguMonoBehavior
{

    private void FixedUpdate()
    {
        this.CheckDespawn();
    }

    protected virtual void CheckDespawn()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObject();
    }

    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
    protected abstract bool CanDespawn();
}
